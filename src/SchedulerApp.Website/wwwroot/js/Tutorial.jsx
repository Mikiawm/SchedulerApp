var CommentBox = React.createClass({
    getInitialState: function () {
        return { data: [] };
    },
    loadCommentsFromServer: function () {
        var xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        console.log(this.props.url);
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            this.setState({ data: data });
        }.bind(this);
        xhr.send();
    },
    componentDidMount: function () {
        this.loadCommentsFromServer();
        window.setInterval(this.loadCommentsFromServer, this.props.pollInterval);
    },
    handleCommentSubmit: function (comment) {
        var data = new FormData();
        data.append('name', comment.name);
        data.append('phoneNumber', comment.phoneNumber);
        data.append('adress', comment.adress);
        for (var pair of data.entries()) {
            console.log(pair[0] + ', ' + pair[1]);
        }
        console.log(this.props.submitUrl);
        var xhr = new XMLHttpRequest();
        xhr.open('Post', this.props.submitUrl, true);
        xhr.onload = function () {
            this.loadCommentsFromServer();
        }.bind(this);
        xhr.send(data);
    },
    render: function () {
        return (
            <div className="commentBox">
                <h1>Comments</h1>
                <CommentList data={this.state.data} />
                <CommentForm onCommentSubmit={this.handleCommentSubmit} />
            </div>
        );
    }
});
var CommentList = React.createClass({
    render: function () {
        var commentNodes = this.props.data.map(function (comment) {
            return (
                <Comment author={comment.name} key={comment.adress}>
                    {comment.phoneNumber}
                </Comment>
            );
        });
        return (
            <div className="commentList">
                {commentNodes}
            </div>
        );
    }
});

var CommentForm = React.createClass({
    getInitialState: function () {
        return { name: '', adress: '', phoneNumber: '' };
    },
    handleNameChange: function (e) {
        this.setState({ name: e.target.value });
    },
    handleAdressChange: function (e) {
        this.setState({ adress: e.target.value });
    },
    handlePhoneNumberChange: function (e) {
        this.setState({ phoneNumber: e.target.value });
    },
    handleSubmit: function (e) {
        e.preventDefault();
        var name = this.state.name.trim();
        var adress = this.state.adress.trim();
        var phoneNumber = this.state.phoneNumber.trim();
        if (!name || !adress || !phoneNumber) {
            return;
        }
        this.props.onCommentSubmit({ name: name, adress: adress, phoneNumber: phoneNumber });
        this.setState({ name: '', adress: '', phoneNumber: '' });
    },
    render: function () {
        return (
            <form className="commentForm" onSubmit={this.handleSubmit}>
                <input
                    type="text"
                    placeholder="Your name"
                    value={this.state.name}
                    onChange={this.handleNameChange}
                />
                <input
                    type="text"
                    placeholder="Adress"
                    value={this.state.adress}
                    onChange={this.handleAdressChange}
                />
                <input
                    type="text"
                    placeholder="PhoneNumber"
                    value={this.state.phoneNumber}
                    onChange={this.handlePhoneNumberChange}
                />
                <input type="submit" value="Post" />
            </form>
        );
    }
});

var Comment = React.createClass({
    rawMarkup: function () {
        var md = new Remarkable();
        var rawMarkup = md.render(this.props.children.toString());
        return { __html: rawMarkup };
    },
    render: function () {
        var md = new Remarkable();
        return (
            <div className="comment">
                <h2 className="commentAuthor">
                    {this.props.author}
                </h2>
                <span dangerouslySetInnerHTML={this.rawMarkup()} />
            </div>
        );
    }
});

ReactDOM.render(
    <CommentBox url="/contacts" submitUrl="/contact/new" editUrl="/contact/edit" pollInterval={2000} />,
    //React.createElement(CommentBox, null),
    document.getElementById('content')
);
