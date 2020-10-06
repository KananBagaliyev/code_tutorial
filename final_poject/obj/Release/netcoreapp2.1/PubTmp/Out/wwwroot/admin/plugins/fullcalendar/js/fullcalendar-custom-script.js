$(document).ready(function () {
    var selectedEvent = null;
    var events = [];
    renderCalendar();
    function renderCalendar()
    {
        events = [];
        $.ajax({
            method: "GET",
            url: "/Admin/Calendar/GetEvents",
            success: function (data) {
                for (var event of data) {
                    events.push({
                        eventId: event.id,
                        title: event.subject,
                        description: event.description,
                        start: event.startingDate,
                        end: event.endingDate
                    });
                }
                console.log(events);
                createCalendar(events);
            }
        })
    }
    

    function createCalendar(events)
    {
        $('#calendar').fullCalendar({
            locale: 'tr',
            buttonText: {
                month: 'Ay',
                agendaDay: 'Gün',
                agendaWeek: 'İl',
                today: 'Bu gün'
            },
            monthNames:

                ['Yanvar', 'Fevral', 'Mart', 'Aprel', 'May', 'İyun', 'İyul', 'Avqust', 'Sentyabr', 'Oktyabr', 'Noyabr', 'Dekabr']
            ,
            dayNames: ['Bazar', 'Bazar ertəsi', 'Çərşənbə axşamı', 'Çərşənbə', 'Cümə axşamı', 'Cümə', 'Şənbə'],
            dayNamesShort: ['Bazar', 'Baz ert', 'Çər ax', 'Çər', 'Cümə ax', 'Cümə', 'Şən'],
            monthNamesShort: ['Yan', 'Fev', 'Mart', 'Apr', 'May', 'Iyun', 'Iyul', 'Avq', 'Sent', 'Okt', 'Noy', 'Dek'],
            firstDay: 1,
            header: {
                left: 'prev,next today',
                center: 'title',
                right: 'month,agendaWeek,agendaDay',
            },
            defaultDate: moment().format("YYYY-MM-DD"),
            navLinks: true, // can click day/week names to navigate views
            selectable: true,
            selectHelper: true,
            select: function (start, end) {
                var title = prompt('Event Title:');
                var eventData;
                if (title) {
                    eventData = {
                        title: title,
                        start: start,
                        end: end
                    };
                    $('#calendar').fullCalendar('renderEvent', eventData, true); // stick? = true
                }
                $('#calendar').fullCalendar('unselect');
            },
            events: events,
            eventClick: function (calEvent, jsEvent, view) {
                selectedEvent = calEvent;
                $('#modal-animation-14 #eventTitle').text(calEvent.title);
                var desc = $('<div/>')

                desc.append($('<p/>').html('<b>Başlayır:</b>' + calEvent.start.format("DD-MMM-YYYY HH:mm a")));
                if (calEvent.end != null)
                {
                    desc.append($('<p/>').html('<b>Bitir:</b>' + calEvent.end.format("DD-MMM-YYYY HH:mm a")));
                }
                desc.append($('<p/>').html('<b>Qısa məlumat:</b>' + calEvent.description));

                $('#modal-animation-14 #eDetails').empty().html(desc);

                $('#modal-animation-14').modal();
                
            },
            selectable: true,
            select: function (start, end) {
                selectedEvent = {
                    eventId: 0,
                    title: '',
                    description: '',
                    start: start,
                    end: end,
                };
                editForm();
                $('#calendar').fullCalendar('unselect');
            },
            editable: true,
            eventDrop: function (event) {
                var data = {
                    Id: event.eventId,
                    Subject: event.title,
                    StartingDate: event.start.format('MM/DD/YYYY HH:mm A'),
                    EndingDate: event.end != null ? event.end.format('MM/DD/YYYY HH:mm A') : null,
                    Description: event.description,
                };
                SaveEvent(data);
            }
        });
        console.log(events);
    }


    $('#btnEdit').click(function () {
        editForm();
    })

    $('#btnDelete').click(function () {
        if (selectedEvent != null && confirm('Əminsiniz?'))
        {
            $.ajax({
                type: 'POST',
                url: '/Admin/Calendar/DeleteEvent',
                data: {'eventId':selectedEvent.eventId},
                success: function (data) {
                    if (data) {
                        renderCalendar();
                        $('#modal-animation-14').modal('hide');
                        location.reload()
                    }
                },
                error: function () {
                    alert('Failed')
                }
            })
        }
    })

    function editForm()
    {
        console.log()
        if (selectedEvent != null) {
            $('#hdEventId').val(selectedEvent.eventId);
            $('#txtSubject').val(selectedEvent.title);
            $('#txtStart').val(selectedEvent.start.format('MM/DD/YYYY HH:mm A'));
            $('#txtEnd').val(selectedEvent.end != null ? selectedEvent.end.format('MM/DD/YYYY HH:mm A') : '');
            $('#txtDesc').val(selectedEvent.description);
        }
        $('#modal-animation-14').modal('hide');
        $('#formemodal').modal();
    }

    $('#btnSave').click(function () {
        //Validation/
        if ($('#txtSubject').val().trim() == "") {
            alert('Subject required');
            return;
        }
        if ($('#txtStart').val().trim() == "") {
            alert('Start date required');
            return;
        }
        else {
            var startDate = moment($('#txtStart').val(), "MM/DD/YYYY HH:mm A").toDate();
            var endDate = moment($('#txtEnd').val(), "MM/DD/YYYY HH:mm A").toDate();
            if (endDate!=null && startDate > endDate) {
                alert('Invalid end date');
                return;
            }
        }

        var data = {
            Id: $('#hdEventId').val(),
            Subject: $('#txtSubject').val().trim(),
            StartingDate: $('#txtStart').val().trim(),
            EndingDate: $('#txtEnd').val().trim(),
            Description: $('#txtDesc').val(),
        }
        SaveEvent(data);
        // call function for submit data to the server 
    })

    function SaveEvent(data) {
        $.ajax({
            type: "POST",
            url: '/Admin/Calendar/SaveEvent',
            data: data,
            success: function (data) {
                if (data) {
                    $('#formemodal').modal('hide');
                    renderCalendar();
                    location.reload();
                }
            },
            error: function () {
                alert('Failed');
            }
        })
    }

    
  });