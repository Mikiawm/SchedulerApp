var Calendar = React.createClass({
    calc: function (year, month) { },
    componentWillMount: function () { },
    componentDidMount: function () {
        this.loadEventsFromServer();
        window.setInterval(this.loadEventsFromServer, this.props.pollInterval);
    },
    loadEventsFromServer: function () {
        var xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            this.setState({ events: data });
        }.bind(this);
        console.log(this.state.events);
        xhr.send();
    },
    componentDidUpdate: function (prevProps, prevState) { },
    handleAddEventSubmit: function (happening) {
        var data = new FormData();
        var happeningDays = happening.map(function (a) { return a.dayDate.toString(); });
        data.append('happeningDays', happeningDays);
        var xhr = new XMLHttpRequest();
        xhr.open('Post', this.props.submitUrl, true);
        xhr.send(data);
    },
    getInitialState: function () {
        var date = new Date();
        var daysInMonths = [31, (((date.getFullYear() % 4 === 0) && (date.getFullYear() % 100 !== 0)) || (date.getFullYear() % 400 === 0)) ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
        return {
            events: [],
            createCal: {},
            year: date.getFullYear(),
            month: date.getMonth() + 1,
            selectedYear: date.getFullYear(),
            selectedMonth: date.getMonth(),
            selectedDate: date.getDate(),
            selectedDt: new Date(date.getFullYear(), date.getMonth(), date.getDate()),
            startDay: new Date(date.getFullYear(), date.getMonth() - 1, 1).getDay(),
            weeksNumber: null,
            minDate: this.props.minDate ? this.props.minDate : null,
            disablePast: this.props.disablePast ? this.props.disablePast : false,
            dayNames: ['Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa', 'Su'],
            monthNames: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
            monthNamesFull: ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"],
            firstOfMonth: null,
            daysInMonth: daysInMonths[date.getMonth()],
            fieldsToDisplay: 42,
            savingMode: false
        };
    },
    changeToSavingMode: function () {
        this.state.savingMode = !this.state.savingMode;
    },
    setActualWeeks: function (year, month) {
        var firstOfMonth = new Date(year, month - 1, 1).getDay() - 1;
        var date = this.state.daysInMonth + firstOfMonth;
        this.state.weeksNumber = Math.ceil(date / 7);
    },
    createCalendar: function (year, month) {
        {
           this.state.createCal.cache = {};
            var day = 1, i, j, haveDays = true,
                    startDay = new Date(year, month, day).getDay(),
                    daysInMonth = [31, (((year % 4 === 0) && (year % 100 !== 0)) || (year % 400 === 0)) ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31],
                    calendar = [];
            if (this.state.createCal.cache[year]) {
                if (this.state.createCal.cache[year][month]) {
                    return this.state.createCal.cache[year][month];
                }
            } else {
                this.state.createCal.cache[year] = {};
            }
            i = 0;
            while (haveDays) {
                calendar[i] = [];
                for (j = 0; j < 7; j++) {
                    if (i === 0) {
                        if (j === startDay) {
                            calendar[i][j] = day++;
                            startDay++;
                        }
                    } else if (day <= daysInMonth[month]) {
                        calendar[i][j] = day++;
                    } else {
                        calendar[i][j] = "";
                        haveDays = false;
                    }
                    if (day > daysInMonth[month]) {
                        haveDays = false;
                    }
                }
                i++;
            }
            console.log(calendar);
            this.state.createCal.cache = { calendar: function () { return calendar.clone(); }, label: months[month] + " " + year };
        }
    },
    getPrev: function () { },
    getNext: function () { },
    selectDate: function (year, month, date, element) { },
    render: function () {
        this.setActualWeeks(this.state.year, this.state.month);
        this.createCalendar(this.state.year, this.state.month - 1);
        return (
        <div className="r-calendar">
            <div className="r-inner">
                <Header monthNames={this.state.monthNamesFull} month={this.state.month} year={this.state.year} onPrev={this.getPrev} onNext={this.getNext} />
                <CalendarNavigation></CalendarNavigation>
                <CalendarContent month={this.state.month} year={this.state.year} dayNames={this.state.dayNames} startDay={this.state.startDay} weekNumbers={this.state.weekNumbers} daysInMonth={this.state.daysInMonth} fieldsToDisplay={this.state.fieldsToDisplay} handleAddEventSubmit={this.handleAddEventSubmit} events={this.state.events} />
                <EventBuble savingMode={this.state.saving}></EventBuble>
            </div>
        </div>
    );
    }
});

var CalendarContent = React.createClass({
    render: function () {
        var weeksCount = Array.apply(null, { length: 5 }).map(Number.call, Number);
        var events = this.props.events;
        var startDay = this.props.startDay;
        var dayNames = this.props.dayNames;
        var year = this.props.year;
        var month = this.props.month;
        var daysInMonth = this.props.daysInMonth;
        return (
       <div className="calendarContent" onMouseDown={this.onMouseDownHandler} onMouseUp={this.onMouseUpHandler}>
           return(<DaysHeader dayNames={dayNames}></DaysHeader>
           {weeksCount.map(function (weekNumber) {
               return (<WeekRow month={month} year={year} dayNames={dayNames} startDay={startDay} weekNumber={weekNumber} events={events }></WeekRow>)
           })}

       </div>
        )
    }
});
var Event = React.createClass({
    render: function () {
        return <div className="event"></div>
    }
});
var WeekRow = React.createClass({
    getInitialState: function () {
        return {
            mouseStillDown: false,
            mouseDownTime: 0,
            days: []
        }
    },
    addDayToEvent: function (day) {
        days = this.state.days.push(day);
    },
    sendEventToSave: function () {
        this.props.handleAddEventSubmit(this.state.days);
    },
    onMouseDownHandler: function () {
        this.state.mouseStillDown = true;
        this.forceUpdate();
    },
    onMouseUpHandler: function () {
        this.state.mouseStillDown = false;
        this.sendEventToSave();
        this.forceUpdate();
    },
    render: function () {
        var daysCount = Array.apply(null, { length: 7 }).map(Number.call, Number);
        var events = this.props.events;
        var startDay = this.props.startDay;
        var year = this.props.year;
        var month = this.props.month;
        var mouseStillDown = this.state.mouseStillDown;
        var addDayToEvent = this.addDayToEvent;
        return (
       <div className="calendarDays" onMouseDown={this.onMouseDownHandler} onMouseUp={this.onMouseUpHandler}>{daysCount.map(function (dayNumber) {
               return (<Day dayName={dayNumber} month={month} year={year} mouseStillDown={mouseStillDown} addDayToEvent={addDayToEvent }></Day>)
           })}{events.map(function (event) {
               return (<Event></Event>)
           })}
       </div>
        )
    }
})
var Day = React.createClass({
    dateChanger: function (value) {
        if (value < 10) { value = '0' + value; }
        return value;
    },
    getInitialState: function () {
        return {
            isClicked: false,
            isEditMode: false,
            mouseDownTime: 0,
            className: "",
            mouseStillDown: false,
            dayDate: new Date(this.props.year, this.props.month, this.props.Number).getDay(),
            dayDateFull: this.props.year + "-" + this.dateChanger(this.props.month) + "-" + this.dateChanger(this.props.Number)
        };
    },
    onClickHandler: function () {
        if (this.state.isEditMode) {

        }
        else {
            this.state.className = this.state.isClicked ? "" : "clickedDay";
            this.state.isClicked = !this.state.isClicked;
            this.forceUpdate();
            console.log(this.props);
        }
    },
    onMouseEnterHandler: function () {
        if (this.props.mouseStillDown) {
            this.state.className = "clickedDay";
            this.props.addDayToEvent({ dayDate: this.state.dayDateFull });
            this.forceUpdate();
        }
    },
    onMouseLeaveHandler: function () {
        this.state.mouseStillDown = false;
        this.state.mouseDownTime = 0;
    },
    onMouseUpHandler: function () {
        this.state.mouseStillDown = false;
        this.state.mouseDownTime = 0;
    },
    onMouseDownHandler: function () {
        this.state.mouseStillDown = true;
        this.state.className = "clickedDay";
        this.changeToEditMode();
    },
    changeToEditMode: function () {
        if (!this.state.mouseStillDown) { return; }
        if (this.state.mouseDownTime > 10) {
            this.state.isEditMode = true;
            this.state.className = "editDay";
            this.forceUpdate();
        }
        this.state.mouseDownTime++;
        if (this.state.mouseStillDown) { setInterval(this.doSomething, 1000); }
    },
    render: function () {
        return (
        <div className={"day " + this.state.className}
             onClick={this.onClickHandler}
             onMouseDown={this.onMouseDownHandler}
             onMouseUp={this.onMouseUpHandler}
             onMouseEnter={this.onMouseEnterHandler}
             onMouseLeave={this.onMouseLeaveHandler}>{this.props.dayNumber}
        </div>
        )
    }
});
var EventBuble = React.createClass({
    getInitialState: function () {
        return {
            isVisible: false,
            className: ""
        };
    },
    setVisibleState: function () {
        this.state.isVisible = !this.state.isVisible;
    },
    render: function () {
        return (<div className={this.state.className}> </div>

        );
    }
})
var CalendarNavigation = React.createClass({
    statics: {
        year: new Date().getFullYear(),
        month: new Date().getMonth(),
        date: new Date().getDate(),
        today: new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDate())
    },
    render: function () {
        return null;
    }

});
var Header = React.createClass({
    render: function () { return (<div>{this.props.monthNames[this.props.month]}</div>) }
});
var DayHeader = React.createClass({
    render: function () { return (<div className="dayHeader">{this.props.dayName}</div>) }
});

var EmptyDay = React.createClass({
    render: function () { return (<div className="emptyDayField"></div>) }
})
var DaysHeader = React.createClass({
    render: function () {
        return (
               <div>{this.props.dayNames.map(function (dayName) {
                       return (<DayHeader dayName={dayName }></DayHeader>)
                   })
                   }
               </div>
        )
    }
})