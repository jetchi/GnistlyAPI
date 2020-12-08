var ViewModel = function () {
    var self = this;
    self.ideas = ko.observableArray();
    self.error = ko.observable();

    var ideasUri = '/api/ideas/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllIdeas() {
        ajaxHelper(ideasUri, 'GET').done(function (data) {
            self.ideas(data);
        });
    }
};
    // Fetch the initial data.
    getAllIdeas();


    ko.applyBindings(new ViewModel());

    self.detail = ko.observable();

    self.getIdeaDetail = function (item) {
        ajaxHelper(ideasUri + item.IdeaID, 'GET').done(function (data) {
            self.detail(data);
        });
    }

    self.users = ko.observableArray();
    self.newIdea = {
        IdeaAuthor: ko.observable(),
        IdeaDescription: ko.observable(),
        IdeaTitle: ko.observable(),
        IdeaDate: ko.observable(),
        IdeaImpact: ko.observable(),
        IdeaEffort: ko.observable(),
        IdeaChallenges: ko.observable(),
        IdeaResults: ko.observable(),
        IdeaSavings: ko.observable(),
        IIdeaID: ko.observable(),
    }

    var usersUri = '/api/users/';

    function getusers() {
        ajaxHelper(usersUri, 'GET').done(function (data) {
            self.users(data);
        });
    }

    self.addBook = function (formElement) {
        var book = {
            AuthorId: self.newBook.Author().Id,
            Genre: self.newBook.Genre(),
            Price: self.newBook.Price(),
            Title: self.newBook.Title(),
            Year: self.newBook.Year()
        };

        ajaxHelper(ideasUri, 'POST', idea).done(function (item) {
            self.ideas.push(item);
        });
    }   

    getUsers();