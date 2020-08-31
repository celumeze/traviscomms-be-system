function spUpdate(containerId, id, accountHolderId, doc) {
    var context = getContext();
    var container = context.getCollection();
    var response = context.getResponse();

    var json = JSON.parse(doc);

    var filterQuery =
    {
        'query': 'select * from '+ containerId + ' c where c.id = @id and c.accountHolderId = @accountHolderId',
        'parameters': [{ 'name': '@id', 'value': id }, { 'name': '@accountHolderId', 'value': accountHolderId }]
    };

    var accept = container.queryDocuments(container.getSelfLink(), filterQuery, {},
        function (err, items, responseOptions) {
            if (err) throw new Error("Error" + err.message);

            if (items.length != 1) throw "Unable to find item in db";
            itemToUpdate = items[0];
            updateItem(itemToUpdate);
            return;
        });
    if (!accept) throw "Unable to read item from db";

    function updateItem(itemToUpdate) {
        if (containerId === "ContactDetails") updateContactDetails(json, itemToUpdate);
        
        var accept = container.replaceDocument(itemToUpdate._self, itemToUpdate,
            function (err, itemReplaced) {
                if (err) throw "Unable to update item";
                response.setBody(itemToUpdate.id);
            });
        if (!accept) throw "Unable to update item";
    }

    function updateContactDetails(contact, itemToUpdate) {
        itemToUpdate.firstName = contact.firstName;
        itemToUpdate.lastName = contact.lastName;
        itemToUpdate.contactNumber = contact.contactNumber;
        itemToUpdate.customAttribute1 = contact.customAttribute1;
        itemToUpdate.customAttribute2 = contact.customAttribute2;
        itemToUpdate.customAttribute3 = contact.customAttribute3;
        itemToUpdate.customAttribute4 = contact.customAttribute4;
        itemToUpdate.customAttribute5 = contact.customAttribute5;
        itemToUpdate.customAttribute6 = contact.customAttribute6;
        itemToUpdate.customAttribute7 = contact.customAttribute7;
        itemToUpdate.customAttribute8 = contact.customAttribute8;
        itemToUpdate.customAttribute9 = contact.customAttribute9;
        itemToUpdate.customAttribute10 = contact.customAttribute10;
    }
}