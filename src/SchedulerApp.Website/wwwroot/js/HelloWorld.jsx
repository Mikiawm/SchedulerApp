var HelloWorld = React.createClass({

    getInitialState: function () {
        return { name: '' };
    },
    componentDidMount: function () {
        $.ajax({
            url: this.,
            dataType: 'json',
            success: function (data) {
                this.setState(date) =>
                {
                    return ()d
                }
            }.bind(this),
            error: function (xhr, status, err) {
                console.error(this.props.url, status, err.toString());
            }.bind(this)
        });
    },
    render: function () {
        foreach(var x in this.state)
        {
        
        }
        return (
        <div> Hello {this.state.name} </div>
        );
    }
});
React.render(
    <HelloWorld url="/home/Contact" />,
    document.getElementById('content')
);