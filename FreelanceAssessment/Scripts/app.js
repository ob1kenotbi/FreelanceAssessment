var ViewModel = function () {
    var self = this;
    self.freelances = ko.observableArray();
    self.error = ko.observable();

    var freelancesUri = '/api/freelances/';

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

    function getAllFreelances() {
        ajaxHelper(freelancesUri, 'GET').done(function (data) {
            self.freelances(data);
        });
    }

    // Fetch the initial data.
    getAllFreelances();

    // Get detail
    self.detail = ko.observable();

    self.getFreelanceDetail = function (item) {
        ajaxHelper(freelancesUri + item.Id, 'GET').done(function (data) {
            self.detail(data);
        });
    }

    // Add new freelance
    self.newFreelance = {
        username: ko.observable(),
        email: ko.observable(),
        phone: ko.observable(),
        skillsets: ko.observable(),
        hobby: ko.observable()
    }

    self.addFreelance = function (formElement) {
        var freelance = {
            username: self.newFreelance.username(),
            email: self.newFreelance.email(),
            phone: self.newFreelance.phone(),
            skillsets: self.newFreelance.skillsets(),
            hobby: self.newFreelance.hobby()
        };

        ajaxHelper(freelancesUri, 'POST', freelance).done(function (item) {
            self.freelances.push(item);
        });
    }

    // Update Freelance
    self.updateFreelance = function (item) {
        var updatedFreelance = {
            Id: item.Id, // Include the ID of the freelance to be updated
            username: item.username,
            email: item.email,
            phone: item.phone,
            skillsets: item.skillsets,
            hobby: item.hobby
        };

        ajaxHelper(freelancesUri + item.Id, 'PUT', updatedFreelance).done(function (updatedItem) {
            // Replace the existing item with the updated item in the observableArray.
            var index = self.freelances.indexOf(item);
            self.freelances.splice(index, 1, updatedItem);
        });
    };

    // Remove Freelance
    self.removeFreelance = function (item) {
        // Perform the removal logic here, for example, sending a DELETE request to the server.
        ajaxHelper(freelancesUri + item.Id, 'DELETE').done(function () {
            // If the server confirms successful deletion, remove the item from the observableArray.
            self.freelances.remove(item);
        });
    };
};

ko.applyBindings(new ViewModel());
