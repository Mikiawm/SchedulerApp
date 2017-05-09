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
            month: date.getMonth(),
            daysInMonth: daysInMonths[date.getMonth()],
            selectedYear: date.getFullYear(),
            selectedMonth: date.getMonth(),
            selectedDate: date.getDate(),
            selectedDt: new Date(date.getFullYear(), date.getMonth(), date.getDate()),
            startDay: 1,
            weekNumbers: false,
            minDate: this.props.minDate ? this.props.minDate : null,
            disablePast: this.props.disablePast ? this.props.disablePast : false,
            dayNames: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'],
            monthNames: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
            monthNamesFull: ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"],
            firstOfMonth: null
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
                    <WeekDays dayNames={this.state.dayNames} startDay={this.state.startDay} weekNumbers={this.state.weekNumbers} daysInMonth={this.state.daysInMonth} />
                    <MonthDates month={this.state.month} year={this.state.year} daysInMonth={this.state.daysInMonth} firstOfMonth={this.state.firstOfMonth} startDay={this.state.startDay} onSelect={this.selectDate} weekNumbers={this.state.weekNumbers} disablePast={this.state.disablePast} minDate={this.state.minDate} />
                </div>
            </div>
        );
    }
});

var Header = React.createClass({
    render: function () { return (<div>{this.props.monthNames[this.props.month]}</div>) }
});

var WeekDays = React.createClass({
    render: function () {
        
        return (<div>{this.props.daysInMonth}</div>)

    }
});

//var Day = React.createClass({
//    render: function () {
//        return (
//                <div style="width: 50px; height: 50px"></div>
//    )
//    }
//});

var MonthDates = React.createClass({
    statics: {
        year: new Date().getFullYear(),
        month: new Date().getMonth(),
        date: new Date().getDate(),
        today: new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDate())
    },
    render: function () {
        return (
                <div></div>
        )
    }
});
