var Calendar = React.createClass({
    calc: function (year, month) { },
    componentWillMount: function () { },
    componentDidMount: function () { },
    componentDidUpdate: function (prevProps, prevState) { },
    handleAddEventSubmit: function (happening) {
        var data = new FormData();
        var happeningDays = happening.map(function (a) { return a.dayDate.toString(); });
        console.log(happening);
        data.append('happeningDays', happeningDays);
        for (var pair of data.entries()) {
            console.log(pair[0] + ', ' + pair[1]);
        }
        console.log(data);
        var xhr = new XMLHttpRequest();
        xhr.open('Post', this.props.submitUrl, true);
        //xhr.onload = function () {
        //    this.loadContactsFromServer();
        //}.bind(this);
        xhr.send(data);
    },
    getInitialState: function () {
        var date = new Date();
        var daysInMonths = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
        return {
            year: date.getFullYear(),
            month: date.getMonth() + 1,
            selectedYear: date.getFullYear(),
            selectedMonth: date.getMonth(),
            selectedDate: date.getDate(),
            selectedDt: new Date(date.getFullYear(), date.getMonth(), date.getDate()),
            startDay: new Date(date.getFullYear(), date.getMonth() - 1, 1).getDay(),
            weekNumbers: [1, 2, 3, 4],
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
    getPrev: function () { },
    getNext: function () { },
    selectDate: function (year, month, date, element) { },
    render: function () {
        return (
        <div className="r-calendar">
            <div className="r-inner">
                <Header monthNames={this.state.monthNamesFull} month={this.state.month} year={this.state.year} onPrev={this.getPrev} onNext={this.getNext} />
                <DaysHeader dayNames={this.state.dayNames} startDay={this.state.startDay} weekNumbers={this.state.weekNumbers} />
                <WeekDays month={this.state.month} year={this.state.year} dayNames={this.state.dayNames} startDay={this.state.startDay} weekNumbers={this.state.weekNumbers} daysInMonth={this.state.daysInMonth} fieldsToDisplay={this.state.fieldsToDisplay} handleAddEventSubmit={this.handleAddEventSubmit} />
                <MonthDates month={this.state.month} year={this.state.year} daysInMonth={this.state.daysInMonth} firstOfMonth={this.state.firstOfMonth} startDay={this.state.startDay} onSelect={this.selectDate} weekNumbers={this.state.weekNumbers} disablePast={this.state.disablePast} minDate={this.state.minDate} />
                <EventBuble savingMode={this.state.saving}></EventBuble>
            </div>
        </div>
    );
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
        var weeksCount = this.props.weekNumbers;
        return (
               <div>
                   {this.props.dayNames.map(function (dayName) {
                       return (<DayHeader dayName={dayName }></DayHeader>)
                   })
                   }
               </div>
        )
    }
});

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
            dayDate: new Date(this.props.year, this.props.month, this.props.dayName).getDay(),
            dayDateFull: this.props.year + "-" + this.dateChanger(this.props.month) + "-" + this.dateChanger(this.props.dayName)
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
        console.log(this.props.mouseStillDown);
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
        console.log(this.state.mouseDownTime);
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
             onMouseLeave={this.onMouseLeaveHandler}>
            {this.props.dayNumber}
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
var WeekDays = React.createClass({
    getInitialState: function () {
        return {
            mouseStillDown: false,
            mouseDownTime: 0,
            days: []
        }
    },
    addDayToEvent: function (day) {
        console.log(day);
        days = this.state.days.push(day);
    },
    sendEventToSave: function () {
        this.props.handleAddEventSubmit(this.state.days);
    },
    onMouseDownHandler: function () {
        console.log("onMouseDownHandler");

        this.state.mouseStillDown = true;
        this.forceUpdate();
    },
    onMouseUpHandler: function () {
        this.state.mouseStillDown = false;
        this.sendEventToSave();
        this.forceUpdate();
    },
    render: function () {
        var daysCount = Array.apply(null, { length: 42 }).map(Number.call, Number);
        var startDay = this.props.startDay;
        var year = this.props.year;
        var month = this.props.month;
        var daysInMonth = this.props.daysInMonth;
        var mouseStillDown = this.state.mouseStillDown;
        var addDayToEvent = this.addDayToEvent;
        return (
       <div className="calendarDays" onMouseDown={this.onMouseDownHandler} onMouseUp={this.onMouseUpHandler}>
           {daysCount.map(function (dayNumber) {
               if (dayNumber > startDay && dayNumber <= startDay + daysInMonth) {
                   return (<Day dayName={dayNumber - startDay} month={month} year={year} mouseStillDown={mouseStillDown} addDayToEvent={addDayToEvent }></Day>)
               }
               else {
                   return (<EmptyDay></EmptyDay>)
               }
           })
           }
       </div>
        )
    }
});

var MonthDates = React.createClass({
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
