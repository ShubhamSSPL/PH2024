$.fn.hasAttr = function (name) {
    return this.attr(name) !== undefined;
};
function SetupCountDown() {
    var TableRows = $('.DataGrid tr').length;
    for (var i = 1; i < TableRows; i++) {
        if (i > 0) {
            var ColumnLength = $('.DataGrid tr').eq(i).find('td').length;
            var IsAlreadyGoneInMessage = false;
            if (ColumnLength === 5) {
                var StartEventDateTime = ExtractDateTime($('.DataGrid tr').eq(i).find('td:nth-child(3)').text());
                var EndEventDateTime = ExtractDateTime($('.DataGrid tr').eq(i).find('td:nth-child(4)').text());
                var DifferenceInDaysToStartEvent;
                if (moment(StartEventDateTime).format('HH:mm') === '00:00' && (!moment(moment(StartEventDateTime).format('YYYY/MM/DD')).isSame(moment().format('YYYY/MM/DD'))) && (moment(StartEventDateTime).format('YYYY/MM/DD') > moment().format('YYYY/MM/DD'))) {
                    var date = moment(StartEventDateTime).format('YYYY/MM/DD');
                    StartEventDateTime = moment(date, 'YYYY/MM/DD').add('days', 1).format('YYYY/MM/DD');
                }
                DifferenceInDaysToStartEvent = moment(StartEventDateTime).diff(moment(), 'days');
                if (parseInt(DifferenceInDaysToStartEvent) === 0 && (moment(StartEventDateTime) > moment())) {
                    if (moment(StartEventDateTime).format('HH:mm') === '00:00' && (moment(StartEventDateTime) > moment())) {
                        $('.DataGrid tr').eq(i).find('td:nth-child(5)').html('<div>Event Will Start Tomorrow</div>');
                        IsAlreadyGoneInMessage = true;
                    }
                    else {
                        $('.DataGrid tr').eq(i).find('td:nth-child(5)').html('<div data-countdown="' + moment(StartEventDateTime).format('YYYY/MM/DD HH:mm') + '"></div>');
                        IsAlreadyGoneInMessage = true;
                    }
                }
                else if (moment(StartEventDateTime).format('HH:mm') === '00:00' && moment(moment(StartEventDateTime).format('YYYY/MM/DD')).isSame(moment().format('YYYY/MM/DD'))) {
                    $('.DataGrid tr').eq(i).find('td:nth-child(5)').html('<div>Event Starts Today</div>');
                    IsAlreadyGoneInMessage = true;
                }
                if (DifferenceInDaysToStartEvent === 1) {
                    $('.DataGrid tr').eq(i).find('td:nth-child(5)').html('<div>' + DifferenceInDaysToStartEvent + ' Day Remaining To Start.</div>');
                    IsAlreadyGoneInMessage = true;
                }
                else if (DifferenceInDaysToStartEvent > 1) {
                    $('.DataGrid tr').eq(i).find('td:nth-child(5)').html('<div>' + DifferenceInDaysToStartEvent + ' Days Remaining To Start.</div>');
                    IsAlreadyGoneInMessage = true;
                }
                else if (moment(StartEventDateTime) < moment()) {
                    var DifferenceInDaysToEndEvent;
                    if (IsAlreadyGoneInMessage === false) {
                        if (moment(EndEventDateTime).format('HH:mm') === '00:00') {
                            var date = moment(EndEventDateTime).format('YYYY/MM/DD');
                            EndEventDateTime = moment(date, 'YYYY/MM/DD').add('days', 1).format('YYYY/MM/DD');
                        }
                        DifferenceInDaysToEndEvent = moment(EndEventDateTime).diff(moment(), 'days');
                        if (parseInt(DifferenceInDaysToEndEvent) === 0 && (moment(EndEventDateTime).format('YYYY/MM/DD HH:mm') > moment().format('YYYY/MM/DD HH:mm'))) {
                            if (moment(EndEventDateTime).format('HH:mm') !== '00:00') {
                                $('.DataGrid tr').eq(i).find('td:nth-child(5)').html('<div class="OngoingEvent" data-countdown="' + moment(EndEventDateTime).format('YYYY/MM/DD HH:mm') + '"></div>');
                            }
                        }
                        else if (parseInt(DifferenceInDaysToEndEvent) === 1) {
                            if (moment(EndEventDateTime).format('HH:mm') === '00:00') {
                                $('.DataGrid tr').eq(i).find('td:nth-child(5)').html('<div>Event Will End Tomorrow</div>');
                            }
                            else {
                                $('.DataGrid tr').eq(i).find('td:nth-child(5)').html('<div>' + DifferenceInDaysToEndEvent + ' Day Remaining To End.</div>');
                            }
                        }
                        else if (DifferenceInDaysToEndEvent > 1) {
                            $('.DataGrid tr').eq(i).find('td:nth-child(5)').html('<div>' + DifferenceInDaysToEndEvent + ' Days Remaining To End.</div>');
                        }
                        else if (DifferenceInDaysToEndEvent < 1) {
                            if (moment(EndEventDateTime).format('HH:mm') === '00:00') {
                                $('.DataGrid tr').eq(i).find('td:nth-child(5)').html('<div>Event Will End Today</div>');
                            }
                            else {
                                var duration = moment.duration(moment() - moment(EndEventDateTime));
                                var hours = duration.asHours();
                                if (parseInt(hours) < 24) {
                                    duration = moment.duration(moment() - moment(EndEventDateTime)).humanize();
                                    $('.DataGrid tr').eq(i).find('td:nth-child(5)').html('<div>Event Ended ' + duration + ' ago </div>');
                                }
                                else {
                                    duration = moment.duration(moment() - moment(EndEventDateTime)).humanize();
                                    $('.DataGrid tr').eq(i).find('td:nth-child(5)').html('<div>Event Ended ' + duration + ' Before </div>');
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    $('[data-countdown]').each(function () {
        var $this = $(this), finalDate = $(this).data('countdown');
        if ($(this).hasClass('OngoingEvent')) {
            $this.countdown(finalDate, function (event) {
                $this.html(event.strftime('%H Hours : %M Minutes Remaining To End '));
            }).on('finish.countdown', SayAlert($(this)));
        }
        else {
            $this.countdown(finalDate, function (event) {
                $this.html(event.strftime('%H Hours : %M Minutes  Remaining To Start '));
            }).on('finish.countdown', SayAlert($(this)));
        }
    });
}
function SayAlert(Element) {
    var RowIndex;
    var EndEventDateTime;
    var DifferenceInDays;
    var Row;
    if (containsWord($(Element).html().trim(), "00 Hours : 00 Minutes ")) {
        $(Element).closest('tr').addClass('OngoingEvent');
        RowIndex = $('.DataGrid tr').index($(Element).closest('tr'));
        EndEventDateTime = ExtractDateTime($(Element).closest('tr').find('td:nth-child(4)').text());
        DifferenceInDays = (moment(EndEventDateTime)).diff(moment(), 'days');
        $(Element).find('td:nth-child(5)').empty();
        Row = $(Element).closest('tr');
        $(Element).closest('tr').remove();
        $(Row).find('td:nth-child(5)').remove();
        if (DifferenceInDays === 0) {
            $(Row).append('<td><div data-countdown="' + moment(EndEventDateTime).format('YYYY/MM/DD HH:mm') + '"></div></td>');
        }
        $('.DataGrid > tbody > tr').eq(RowIndex - 1).after($(Row));
    }
}
$(document).ready(function () {
    var timer = null;
    SetupCountDown();
    timer = setInterval(SetupCountDown, 1000);
});
function containsWord(WholeString, SearchString) {
    return (" " + WholeString + " ").indexOf(" " + SearchString + " ") !== -1;
}
function ExtractDateTime(MixedDateTime) {
    var EndDateTimeText = MixedDateTime.toUpperCase();
    var ExtractedDateTime;
    var SeparateDateTime = EndDateTimeText.trim().split(' ');
    var DateIndex;
    for (var i = 0; i < SeparateDateTime.length; i++) {
        if (SeparateDateTime[i].length > 0) {
            if (SeparateDateTime[i].indexOf('/') > 0) {
                var CountSlashes = SeparateDateTime[i].match(/\//g);
                if (CountSlashes.length === 2) {
                    DateIndex = i;
                    break;
                }
            }
        }
    }
    var chunks = SeparateDateTime[DateIndex].split('/');
    var TimeIndex = -1;
    for (var i = 0; i < SeparateDateTime.length; i++) {
        if (SeparateDateTime[i].length > 0) {
            if (SeparateDateTime[i].indexOf(':') > 0) {
                TimeIndex = i;
                break;
            }
        }
    }
    var AMPMIndex;
    for (var i = 0; i < SeparateDateTime.length; i++) {
        if (SeparateDateTime[i].length > 0) {
            if (SeparateDateTime[i] === 'AM') {
                AMPMIndex = i;
                break;
            }
            if (SeparateDateTime[i] === 'PM') {
                AMPMIndex = i;
                break;
            }
        }
    }
    var NewTime;
    var FormattedDate = chunks[2] + '-' + chunks[1] + '-' + chunks[0];
    if (TimeIndex >= 0) {
        var TimeChunks;
        if (SeparateDateTime[AMPMIndex] === 'PM') {
            TimeChunks = SeparateDateTime[TimeIndex].split(':');
            if (parseInt(TimeChunks[0]) < 12) {
                NewTime = (parseInt(TimeChunks[0]) + parseInt(12)) + ':' + TimeChunks[1];
            }
            else {
                NewTime = (parseInt(TimeChunks[0])) + ':' + TimeChunks[1];
            }
        }
        else {
            TimeChunks = SeparateDateTime[TimeIndex].split(':');
            NewTime = (parseInt(TimeChunks[0])) + ':' + TimeChunks[1];
        }

        ExtractedDateTime = moment(FormattedDate + ' ' + NewTime).format();
    } else {
        ExtractedDateTime = moment(FormattedDate).format();
    }
    return ExtractedDateTime;
}