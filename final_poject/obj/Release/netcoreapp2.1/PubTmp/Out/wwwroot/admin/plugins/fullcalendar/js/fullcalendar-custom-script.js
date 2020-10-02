$(document).ready(function() {

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
        dayNames: ['Bazar', 'Bazar ertəsi', 'Çərşənbə axşamı', 'Çərşənbə','Cümə axşamı', 'Cümə', 'Şənbə'],
        dayNamesShort: ['Bazar', 'Baz ert', 'Çər ax', 'Çər', 'Cümə ax', 'Cümə', 'Şən'],
        monthNamesShort: ['Yan', 'Fev', 'Mart', 'Apr', 'May', 'Iyun','Iyul', 'Avq', 'Sent', 'Okt', 'Noy', 'Dek'],
        firstDay:1,
      header: {
        left: 'prev,next today',
        center: 'title',
        right: 'month,agendaWeek,agendaDay',
      },
      defaultDate: moment().format("YYYY-MM-DD"),
      navLinks: true, // can click day/week names to navigate views
      selectable: true,
      selectHelper: true,
      select: function(start, end) {
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
      editable: true,
      eventLimit: true, // allow "more" link when too many events
      events: [
      ]
    });
  });