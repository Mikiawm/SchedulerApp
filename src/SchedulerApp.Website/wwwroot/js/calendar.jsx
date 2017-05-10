var Calendar = React.createClass({
    calc: function (year, month) { },
    componentWillMount: function () { },
    componentDidMount: function () { },
    componentDidUpdate: function (prevProps, prevState) { },
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
            fieldsToDisplay: 42
        };
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
                <WeekDays month={this.state.month} year={this.state.year} dayNames={this.state.dayNames} startDay={this.state.startDay} weekNumbers={this.state.weekNumbers} daysInMonth={this.state.daysInMonth} fieldsToDisplay={this.state.fieldsToDisplay}/>
                <MonthDates month={this.state.month} year={this.state.year} daysInMonth={this.state.daysInMonth} firstOfMonth={this.state.firstOfMonth} startDay={this.state.startDay} onSelect={this.selectDate} weekNumbers={this.state.weekNumbers} disablePast={this.state.disablePast} minDate={this.state.minDate} />
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


var Day = React.createClass({
    getInitialState: function() {
        return {
            isClicked: false,
            isEditMode: false,
            mouseDownTime: 0,
            className: "day",
            mouseStillDown: false,
            dayDate: new Date(this.props.year, this.props.month, 1).getDay()
        };
    },
    getComponent: function () {
        if (this.state.isEditMode) {

        }
        else {
            this.state.className = this.state.isClicked ? "day" : "clickedDay";
            this.state.isClicked = !this.state.isClicked;
            this.forceUpdate();
            console.log(this.props);
        }
        
    },
    mouseUp: function () {
        this.state.mouseStillDown = false;
        this.state.mouseDownTime = 0;
    },
    mouseDown: function() {
        this.state.mouseStillDown = true;
        this.doSomething();
    },
    doSomething: function() {
        if (!this.state.mouseStillDown) { return; } 
        console.log(this.state.mouseDownTime);
        if (this.state.mouseDownTime > 10)
        {
            this.state.isEditMode = true;
            this.state.className = "editDay";
            this.forceUpdate();
        }
        this.state.mouseDownTime++;
        if (this.state.mouseStillDown) { setInterval(this.doSomething, 1000); }
    },
    render: function () { return (<div className={this.state.className} onClick={this.getComponent } onMouseDown={this.mouseDown} onMouseUp={this.mouseUp}>{this.props.dayNumber}</div>) }
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
var WeekDays = React.createClass({
    render: function () {
        var daysCount = Array.apply(null, { length: 42 }).map(Number.call, Number);
        var startDay = this.props.startDay;
        var year = this.props.year;
        var month = this.props.month;
        var daysInMonth = this.props.daysInMonth;
        return (
       <div className="calendarDays">
           {daysCount.map(function (dayNumber) {
               if (dayNumber > startDay && dayNumber <= startDay + daysInMonth) {
                   return (<Day dayName={dayNumber - startDay} month={month} year={year}></Day>)
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
