var ContactBox = React.createClass({
    getInitialState: function () {
        return { data: [] };
    },
    loadContactsFromServer: function () {
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
        this.loadContactsFromServer();
        window.setInterval(this.loadContactsFromServer, this.props.pollInterval);
    },
    handleContactAddSubmit: function (contact) {
        var data = new FormData();
        data.append('name', contact.name);
        data.append('phoneNumber', contact.phoneNumber);
        data.append('adress', contact.adress);
        for (var pair of data.entries()) {
            console.log(pair[0] + ', ' + pair[1]);
        }
        console.log(this.props.submitUrl);
        var xhr = new XMLHttpRequest();
        xhr.open('Post', this.props.submitUrl, true);
        xhr.onload = function () {
            this.loadContactsFromServer();
        }.bind(this);
        xhr.send(data);
    },
    handleContactEditSubmit: function (contact) {
        var data = new FormData();
        data.append('id', contact.id);
        data.append('name', contact.name);

        console.log(this.props.submitUrl);
        var xhr = new XMLHttpRequest();
        xhr.open('Post', this.props.editUrl, true);
        xhr.onload = function () {
            this.loadContactsFromServer();
        }.bind(this);
        xhr.send(data);
    },
    render: function () {
        return (
            <div className="contactBox">
                <h1>Contacts</h1>
                <ContactList data={this.state.data} handleContactSubmit={this.handleContactEditSubmit} />
                <ContactForm onContactSubmit={this.handleContactAddSubmit} />
            </div>
        );
    }
});


var ContactForm = React.createClass({
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
        this.props.onContactSubmit({ name: name, adress: adress, phoneNumber: phoneNumber });
        this.setState({ name: '', adress: '', phoneNumber: '' });
    },
    render: function () {
        return (
            <form className="contactForm" onSubmit={this.handleSubmit}>
                <input type="text"
                       placeholder="Your name"
                       value={this.state.name}
                       onChange={this.handleNameChange} />
                <input type="text"
                       placeholder="Adress"
                       value={this.state.adress}
                       onChange={this.handleAdressChange} />
                <input type="text"
                       placeholder="PhoneNumber"
                       value={this.state.phoneNumber}
                       onChange={this.handlePhoneNumberChange} />
                <input type="submit" value="Post" />
            </form>
        );
    }
});
var ContactList = React.createClass({
    render: function () {
        var handle = this.props.handleContactSubmit;
        var contactNodes = this.props.data.map(function (contact) {
            return (
                <Contact onContactSubmit={handle} name={contact.name} id={contact.contactId} >
                    {contact.phoneNumber}
                </Contact>
            );
        });
        return (
    <div className="contactList" handleContactSubmit={this.handleContactEditSubmit}>
        {contactNodes}
    </div>
        );
    }
});
var Contact = React.createClass({
    getInitialState: function () {
        return { name: '', id: this.props.id };
    },
    handleNameChange: function (e) {
        this.setState({ name: e.target.value });
    },
    rawMarkup: function () {
        var md = new Remarkable();
        var rawMarkup = md.render(this.props.children.toString());
        return { __html: rawMarkup };
    },
    handleSubmit: function (e) {
        e.preventDefault();
        var name = this.state.name.trim();
        var id = this.state.id;
        if (name == '') return;
        this.props.onContactSubmit({ name: name, id: id });
        this.setState({ name: '' });
    },
    render: function () {
        var md = new Remarkable();
        return (
            <form className="contact" onSubmit={this.handleSubmit}>
                <input type="text"
                       placeholder="Your name"
                       defaultValue={this.props.name}
                       onChange={this.handleNameChange} />
                <span dangerouslySetInnerHTML={this.rawMarkup()} />
                <input type="submit" value="Post" />
            </form>
        );
    }
});

ReactDOM.render(
    <ContactBox url="/contacts" submitUrl="/contact/new" editUrl="/contact/edit" pollInterval={2000} />,
    document.getElementById('content')
);