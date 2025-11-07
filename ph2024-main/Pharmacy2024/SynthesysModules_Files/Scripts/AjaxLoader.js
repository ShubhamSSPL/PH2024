/************************************************************************************************
Name		- Ajax Loader
Description	- Loading screen, Ajax time keeper and other ajax related functionalities.
Version		- 2.0.2
Author		- Anoop Nair.
Company		- MKCL.

# COPYRIGHT NOTICE
# Copyright (c) 2005-2010 MKCL, All rights reserved.
# This script may be used and modified free of charge for Non-profit purposes by anyone as long
# as this copyright notice and the comments above are kept in their original form.
************************************************************************************************/

if (typeof (Synthesys) == 'undefined')
    window.reload(true);
	//alert('Dear Developer,Please add reference to "FuncLib.js"!\r\nPlease verify version too.');
Synthesys.LoadScreen = function(hideElem, displayText, imageSource)
{
	this.IsLoad = false;
	Synthesys.FuncLib.AddLoadEvent(function() { Synthesys.LoadScreen.IsLoad = true; });
	var mainDiv = document.createElement('div');
	var busyImg = document.createElement('img');
	var txtSpan = document.createElement('span');
	var layTab = document.createElement('table');
	var firstTr = layTab.insertRow(-1);
	var firstTd = firstTr.insertCell(-1);
	var secondTd = firstTr.insertCell(-1);
	firstTd.appendChild(busyImg);
	secondTd.appendChild(txtSpan);
	mainDiv.appendChild(layTab);
	if (Synthesys.LoadScreen.IsLoad)
		document.body.appendChild(mainDiv);
	else
		Synthesys.FuncLib.AddLoadEvent(function() { document.body.appendChild(mainDiv); });
	mainDiv.style.position = 'absolute';
	mainDiv.style.display = 'none';
	mainDiv.style.overflow = 'hidden';
	layTab.style.margin = '0 auto';
	firstTd.style.textAlign = 'right';
	firstTd.style.width = '30%';
	firstTd.style.padding = '0';
	secondTd.style.padding = '0';
	mainDiv.style.verticalAlign = 'middle';
	mainDiv.style.border = '1px solid #E2D7D7';
	mainDiv.style.opacity = 0.93;
	mainDiv.style.filter = 'alpha(opacity=93)';
	mainDiv.style.zIndex = 20;
	var errhnd = new Synthesys.ErrorHandler('LoadScreen', new Array('RequiredArgumentMissing'), 25);
	var self = this, hidElem, disText, imgSrc = imageSource, lastHideElem;
	function afterLoad()
	{
		var windowHeight = hidElem.offsetHeight;
		if ((busyImg.oldHeight && busyImg.oldHeight > windowHeight) ||
			(!busyImg.oldHeight && busyImg.height > windowHeight))
		{
			if (!busyImg.oldHeight)
				busyImg.oldHeight = busyImg.height;
			busyImg.height = windowHeight - 5;
		}
		else if (busyImg.oldHeight)
		{
			busyImg.height = busyImg.oldHeight;
		}
		layTab.style.position = 'static';
		var contentHeight = layTab.offsetHeight;
		if (windowHeight > 0 && windowHeight - contentHeight > 0)
		{
			layTab.style.position = 'relative';
			layTab.style.top = ((mainDiv.offsetHeight / 2) - (contentHeight / 2)) + 'px';
		}
	}
	function setVisibleSelect(elem, show)
	{
		if (elem.nodeName.toLowerCase() == 'select')
		{
			if (show)
			{
				elem.style.visibility = (elem.loader_visibility ? elem.loader_visibility : '');
				elem.loader_visibility = null;
			}
			else
			{
				elem.loader_visibility = elem.style.visibility;
				elem.style.visibility = 'hidden';
			}
		}
		else
		{
			for (var i = 0; i < elem.childNodes.length; i++)
				setVisibleSelect(elem.childNodes[i], show);
		}
	}
	this.DisplayText = txtSpan.innerHTML;
	this.SetHideElement = function(element)
	{
		if (typeof (element) == 'string')
			element = document.getElementById(element);
		hidElem = element;
	};
	this.SetText = function(displayText, isOnlyForDisplay)
	{
		if (!isOnlyForDisplay)
		{
			disText = (displayText ? displayText : "Loading");
			this.DisplayText = disText;
		}
		txtSpan.innerHTML = (displayText ? displayText : "Loading");
	};
	this.Show = function(displayText)
	{
		if (displayText)
			this.SetText(displayText);
		if (!hidElem)
		{
			errhnd.ShowAlert('"hideElement" is not set.', 0, 'LoadScreen.show(displayText)');
			return;
		}
		mainDiv.style.display = '';
		var point = Synthesys.FuncLib.GetOffsetPosition(hidElem);
		mainDiv.style.left = point.X + ((hidElem.nodeName.toLowerCase() == 'input'
			|| hidElem.nodeName.toLowerCase() == 'select') && (Synthesys.Browser.IsChrome
			|| Synthesys.Browser.IsFirefox) ? 1 : 0) + 'px';
		mainDiv.style.top = point.Y + ((hidElem.nodeName.toLowerCase() == 'input'
			|| hidElem.nodeName.toLowerCase() == 'select') && (Synthesys.Browser.IsChrome
			|| Synthesys.Browser.IsFirefox) ? 1 : 0) + 'px';
		mainDiv.style.height = (hidElem.offsetHeight - 2) + 'px';
		mainDiv.style.width = (hidElem.offsetWidth - 2) + 'px';
		mainDiv.style.backgroundColor = 'white';
		Synthesys.FuncLib.RemoveEventHandler(busyImg, 'load', afterLoad);
		Synthesys.FuncLib.AddEventHandler(busyImg, 'load', afterLoad);
		if (Synthesys.Browser.IsChrome)
			busyImg.src = '';
		busyImg.src = (imgSrc ? imgSrc : "../images/BusyIcon.gif");
		afterLoad();
		if (Synthesys.Browser.IsIe && Synthesys.Browser.Version < 7)
		{
			if (lastHideElem && lastHideElem.nodeName.toLowerCase() != 'input')
				setVisibleSelect(lastHideElem, true);
			if (hidElem.nodeName.toLowerCase() != 'input')
				setVisibleSelect(hidElem, false);
		}
		lastHideElem = hidElem;
	};
	this.Hide = function()
	{
		mainDiv.style.display = 'none';
		if (hidElem && hidElem.nodeName.toLowerCase() != 'input'
			&& Synthesys.Browser.IsIe && Synthesys.Browser.Version < 7)
			setVisibleSelect(hidElem, true);
		lastHideElem = null;
	};
	this.SetHideElement(hideElem);
	this.SetText(displayText);
};
Synthesys.AjaxTimeKeeper = function(timeOuts, loaderScreen)
{
	var errhnd = new Synthesys.ErrorHandler('AjaxTimeKeeper', new Array('ArgumentFormat'
		, 'RequiredArgumentMissing', 'InvalidEnvironment', 'InvalidArgument'), 30);
	if (typeof (AjaxPro) == 'undefined' || !AjaxPro.timeoutPeriod)
	{
		errhnd.ShowAlert('Either AJAX is not used in this page \r\nOR\r\n'
			+ '\tCorrect version of "AjaxPro.2.dll" is not used(9.2.17.1).', 2);
		return;
	}
	if (!(timeOuts && !(timeOuts.propertyIsEnumerable('length')) && typeof (timeOuts) === 'object'
		&& typeof (timeOuts.length) === 'number'))
	{
		errhnd.ShowAlert('Parameter "timeOuts"(first param)should be an array.', 0);
		return;
	}
	if (timeOuts.length < 1)
	{
		errhnd.ShowAlert('Parameter "timeOuts"(first param)should contain atleast one timeout value.', 0);
		return;
	}
	if (arguments.length == 2 && !(loaderScreen && typeof (loaderScreen) === 'object'
		&& typeof (loaderScreen.DisplayText) === 'string' && typeof (loaderScreen.SetText) === 'function'))
	{
		errhnd.ShowAlert('Parameter "loaderScreen"(second param)should be a "LoadScreen" object.', 0);
		return;
	}
	if (arguments.length > 2)
		loaderScreen = new Synthesys.LoadScreen(arguments[1], arguments[2], arguments[3]);
	var self = this, curTimer, actTimer, timerObj, dots;
	var ajxArgs, ajxFunc, ajxCls;
	function getDisplayText()
	{
		var output = '', i = 0;
		if (curTimer == 0)
			output += loaderScreen.DisplayText;
		else
			output += 'Retrying';
		for (; i < dots; i++)
			output += '.';
		for (; i <= 3; i++)
			output += '&nbsp;';
		output += '(' + actTimer + 's)';
		return output;
	}
	function setText()
	{
		actTimer--;
		dots++;
		if (dots > 3)
			dots = 0;
		if (actTimer < 0)
			timedOut();
		else
			loaderScreen.SetText(getDisplayText(), true);
	}
	function timedOut()
	{
		stopTimer();
		updateTimer();
	}
	function updateTimer()
	{
		curTimer++;
		actTimer = (curTimer >= timeOuts.length ? null : timeOuts[curTimer]);
		if (actTimer)
		{
			AjaxPro.timeoutPeriod = actTimer * 1000;
			ajxFunc.apply(ajxCls, ajxArgs);
			timerObj = setInterval(function() { setText(); }, 1000);
			actTimer++;
			setText();
		}
		else
		{
			stopTimer();
			loaderScreen.Hide();
			alert('Your internet connectivity seems to be too poor.\r\nServer cannot be reached.'
				+ '\r\nPlease use better connectivity options.');
		}
	}
	function stopTimer()
	{
		if (timerObj)
			clearInterval(timerObj);
		timerObj = null;
	}
	this.LoadScreen = loaderScreen;
	this.Start = function()
	{
		if (arguments.length < 2)
		{
			errhnd.ShowAlert('ATK expects calling and callback functions.', 1);
			return;
		}
		if (typeof (arguments[0]) != 'string')
		{
			errhnd.ShowAlert('Expected calling function name(string)as first argument,found "'
				+ typeof (arguments[0]) + '".', 0);
			return;
		}
		if (typeof (arguments[arguments.length - 1]) != 'function')
		{
			errhnd.ShowAlert('Expected Ajax callback function as last argument,found "'
				+ typeof (arguments[arguments.length - 1]) + '".', 0);
			return;
		}
		try
		{
			ajxFunc = eval(arguments[0]);
		}
		catch (err)
		{
			errhnd.ShowAlert((Synthesys.Browser.IsChrome ? err : err.message), 3);
			return;
		}
		if (typeof (ajxFunc) != 'function')
		{
			errhnd.ShowAlert('"' + arguments[0] + '" is not a function.', 0);
			return;
		}
		var temp = arguments[0].split('.');
		ajxCls = eval(temp.slice(0, temp.length - 1).join('.'));
		ajxArgs = Array.prototype.slice.call(arguments).slice(1);
		loaderScreen.Show();
		curTimer = -1;
		dots = 0;
		AjaxPro.queue.abort();
		stopTimer();
		updateTimer();
	};
	this.Stop = function()
	{
		loaderScreen.Hide();
		stopTimer();
	};
};
