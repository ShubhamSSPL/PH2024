/************************************************************************************************
Name		- Filter Table
Description	- Makes tables filtering enabled.
Version		- 4.0.1
Author		- Anoop Nair.
Company		- Synthesys (part of MKCL).

# COPYRIGHT NOTICE
# Copyright (c) 2005-2010 MKCL, All rights reserved.
# This script may be used and modified free of charge for Non-profit purposes by anyone as long
# as this copyright notice and the comments above are kept in their original form.
************************************************************************************************/

if (typeof (Synthesys) == 'undefined')
	 window.reload(true);
Synthesys.FilterTable = new function()
{
	var tableArray = new Array();
	tableArray[0] = new Array();
	tableArray[1] = new Array();
	tableArray[2] = new Array();
	tableArray[3] = new Array();
	tableArray[4] = new Array();
	tableArray[5] = new Array();
	this.InitAll = function()
	{
		var i = 0, total = 0;
		var tables = document.getElementsByTagName("TABLE");
		for (var i = 0; i < tables.length; i++)
			if (tables[i].getAttribute('Synthesysfilter'))
			AddFilter(tables.item(i), total++);
	};
	this.EditFilter = function(tabFilt, headerRows, footerRows, textColumns, comboColumns)
	{
		if (typeof (tabFilt) == 'string')
			tabFilt = document.getElementById(tabFilt);
		if (typeof (tabFilt) == 'undefined')
		{
			alert('Synthesys.FilterTable- Table cannot be found!');
			return;
		}
		var index = -1;
		var endPos = 0, startPos = -1;
		var colsTemp1 = new Array(), colsTemp2 = new Array();
		if (typeof (footerRows) == 'number')
			endPos = footerRows;
		if (typeof (headerRows) == 'number')
			startPos = headerRows;
		colsTemp1 = textColumns.split(',');
		colsTemp2 = comboColumns.split(',');
		if (typeof (tabFilt.SynthesysFilterIndex) == 'undefined' || !tabFilt.SynthesysFilterIndex)
		{
			index = tableArray[0].length;
			tableArray[0][index] = tabFilt;
			tabFilt.SynthesysFilterIndex = index;
		}
		else
		{
			index = tabFilt.SynthesysFilterIndex;
			ResetFilter(tabFilt, index);
		}
		ProcessFilter(tabFilt, index, endPos, startPos, colsTemp1, colsTemp2);
	};
	this.RemoveFilter = function(tabFilt)
	{
		if (typeof (tabFilt) == 'string')
			tabFilt = document.getElementById(tabFilt);
		if (typeof (tabFilt) == 'undefined')
		{
			alert('Synthesys.FilterTable- Table cannot be found!');
			return;
		}
		if (typeof (tabFilt.SynthesysFilterIndex) != 'undefined' || !tabFilt.SynthesysFilterIndex)
		{
			ResetFilter(tabFilt, tabFilt.SynthesysFilterIndex);
			tabFilt.removeAttribute('SynthesysFilterIndex');
		}
	};
	function ResetFilter(tabFilt, index)
	{
		for (var i = 0; i < tabFilt.rows.length; i++)
			tabFilt.rows[i].style.display = '';
		var newRow = document.getElementById("SynthesysFilterRow" + index);
		if (newRow)
			tabFilt.deleteRow(newRow.rowIndex);
	}
	function AddFilter(tabFilt, index)
	{
		tableArray[0][index] = tabFilt;
		tabFilt.SynthesysFilterIndex = index;
		var attribs = tabFilt.getAttribute('Synthesysfilter').split(';');
		var endPos = 0, startPos = -1;
		var colsTemp1 = new Array(), colsTemp2 = new Array();
		if (attribs[attribs.length - 1].TrimBoth() == "")
			attribs.length--;
		for (i = 0; i < attribs.length; i++)
		{
			var attr = attribs[i].split(':');
			switch (attr[0])
			{
				case 'footer-rows':
					if (Synthesys.FuncLib.IsNumber(attr[1]))
						endPos = parseInt(attr[1]);
					break;
				case 'header-rows':
					if (Synthesys.FuncLib.IsNumber(attr[1]))
						startPos = parseInt(attr[1]);
					break;
				case 'text-columns':
					colsTemp1 = attr[1].split(',');
					break;
				case 'combo-columns':
					colsTemp2 = attr[1].split(',');
					break;
			}
		}
		ProcessFilter(tabFilt, index, endPos, startPos, colsTemp1, colsTemp2);
	}
	function ProcessFilter(tabFilt, index, endPos, startPos, colsTemp1, colsTemp2)
	{
		var i = 0, j = 0;
		var filterColumns = new Array();
		endPos = tabFilt.rows.length - endPos;
		if (startPos == -1)
		{
			for (i = 0; i < tabFilt.rows[0].cells.length; i++)
			{
				if (startPos < tabFilt.rows[0].cells[i].rowSpan)
					startPos = tabFilt.rows[0].cells[i].rowSpan;
			}
		}
		filterColumns.length = tabFilt.rows[startPos].cells.length;
		var init = (colsTemp1.length == 0 && colsTemp2.length == 0 ? 1 : 0);
		for (j = 0; j < filterColumns.length; j++)
		{
			filterColumns[j] = init;
		}
		for (j = 0; j < colsTemp1.length; j++)
		{
			if (Synthesys.FuncLib.IsNumber(colsTemp1[j])
				&& parseInt(colsTemp1[j]) < filterColumns.length)
				filterColumns[parseInt(colsTemp1[j])] = 1;
		}
		for (j = 0; j < colsTemp2.length; j++)
		{
			if (Synthesys.FuncLib.IsNumber(colsTemp2[j])
				&& parseInt(colsTemp2[j]) < filterColumns.length)
				filterColumns[parseInt(colsTemp2[j])] = 2;
		}
		colsTemp1 = null;
		colsTemp2 = null;
		var newRow = tabFilt.insertRow(startPos);
		newRow.id = "SynthesysFilterRow" + index;
		var k = 0;
		for (i = 0; i < tabFilt.rows[startPos + 1].cells.length; i++)
		{
			var newCell = newRow.insertCell(-1);
			if (tabFilt.rows[startPos + 1].cells[i].style.display == "none")
			{
				newCell.style.display = "none";
			}
			if (filterColumns[i] == 2)
			{
				var newSelect = document.createElement("select");
				k = 0;
				newSelect[k++] = new Option("--All--", "");
				newSelect.selectedIndex = 0;
				for (j = startPos + 1; j <= endPos; j++)
					k = AddNewOption(newSelect, Synthesys.FuncLib.GetInnerText(tabFilt.rows[j].cells[i]), k);
				var wid = parseInt(tabFilt.rows[startPos + 1].cells[i].offsetWidth) - 11;
				newSelect.style.width = (wid < 20 ? 20 : wid) + "px";
				newSelect.TableIndex = index;
				newSelect.ColumnIndex = i;
				newSelect.onchange = Synthesys.FilterTable.FilterData;
				newCell.appendChild(newSelect);
			}
			else if (filterColumns[i] == 1)
			{
				var newInput = document.createElement("input");
				newInput.type = "text";
				var wid = parseInt(tabFilt.rows[startPos + 1].cells[i].offsetWidth) - 11;
				newInput.style.width = (wid < 20 ? 20 : wid) + "px";
				newInput.TableIndex = index;
				newInput.ColumnIndex = i;
				newInput.onkeydown = Synthesys.FilterTable.SetFilter;
				newInput.onkeyup = Synthesys.FilterTable.FilterData;
				newCell.appendChild(newInput);
			}
			else
			{
				newCell.appendChild(document.createTextNode(" "));
			}
		}
		tableArray[1][index] = startPos + 1;
		tableArray[2][index] = endPos;
		tableArray[3][index] = -1;
		tableArray[4][index] = filterColumns;
		tableArray[5][index] = new Array();
		for (i = 0; i < filterColumns.length; i++)
			tableArray[5][index][i] = "";
	}
	function AddNewOption(selectBox, newValue, curIndex)
	{
		var i = 0;
		for (; i < selectBox.options.length; i++)
		{
			if (newValue == selectBox.options[i].value)
				break;
		}
		if (i == selectBox.options.length)
			selectBox[curIndex++] = new Option(newValue, newValue);
		return curIndex;
	}
	this.SetFilter = function()
	{
		tableArray[3][this.TableIndex] = this.value.length;
	};
	this.FilterData = function()
	{
		var tableIndex = this.TableIndex, columnNumber = this.ColumnIndex,
			matchRecord = this.value.toLowerCase();
		var grid = tableArray[0][tableIndex];
		var startPos = tableArray[1][tableIndex];
		var endPos = tableArray[2][tableIndex];
		var curLen = matchRecord.length;
		var i = 0, j = 0;
		tableArray[5][tableIndex][columnNumber] = matchRecord;
		var matchData = tableArray[5][tableIndex];
		if (matchRecord == "")
		{
			for (i = startPos; i <= endPos; i++)
				grid.rows[i].style.display =
					(MatchRow(tableIndex, columnNumber, grid.rows[i], matchData) ? '' : 'none');
		}
		else if (tableArray[4][tableIndex][columnNumber] == 2)
		{
			for (i = startPos; i <= endPos; i++)
				grid.rows[i].style.display = (Synthesys.FuncLib.GetInnerText(
					grid.rows[i].cells[columnNumber]).toLowerCase() == matchRecord ?
					(MatchRow(tableIndex, columnNumber, grid.rows[i], matchData) ? '' : 'none') : 'none');
		}
		else if (matchRecord.length < tableArray[3][tableIndex])
		{
			for (i = startPos; i <= endPos; i++)
			{
				if (grid.rows[i].style.display == '')
					continue;
			
			if (Synthesys.FuncLib.GetInnerText(grid.rows[i].cells[columnNumber]).toLowerCase().StartsWith(
				matchRecord) && MatchRow(tableIndex, columnNumber, grid.rows[i], matchData))
				grid.rows[i].style.display = '';
			}	//modified for brackets
		}
		else
		{
			for (i = startPos; i <= endPos; i++)
			{
				if (grid.rows[i].style.display == 'none')
					continue;
			
			if (!Synthesys.FuncLib.GetInnerText(
				grid.rows[i].cells[columnNumber]).toLowerCase().StartsWith(matchRecord))
				grid.rows[i].style.display = 'none';
			}//modified for brackets
		}
	};
	function MatchRow(tableIndex, colNumber, rowData, matchData)
	{
		for (var i = 0; i < rowData.cells.length; i++)
		{
			if (i == colNumber || matchData[i] == "")
				continue;
			if (tableArray[4][tableIndex][i] == 2
				&& Synthesys.FuncLib.GetInnerText(rowData.cells[i]).toLowerCase() != matchData[i])
				return false;
			if (!Synthesys.FuncLib.GetInnerText(rowData.cells[i]).toLowerCase().StartsWith(matchData[i]))
				return false;
		}
		return true;
	}
};
Synthesys.FuncLib.AddLoadEvent(Synthesys.FilterTable.InitAll);