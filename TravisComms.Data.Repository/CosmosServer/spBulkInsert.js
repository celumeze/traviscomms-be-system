function spBulkInsert(items) {
    if (typeof items === "string") items = JSON.parse(items);

    var collection = getContext().getCollection();
    var collectionLink = collection.getSelfLink();
    var count = 0;

    if (!items) throw new Error("Documents empty");
    
    var numItems = items.length;

    if (numItems == 0) {
        getContext().getResponse().setBody(0);
        return;
    }

    tryCreate(items[count], callback);

    function tryCreate(item, callback) {

        var isAccepted = collection.createDocument(collectionLink, item, callback);

        if (!isAccepted) getContext().getResponse().setBody(count);
    }

    function callback(err, item) {
        if (err) throw err;
        count++;
        if (count >= numItems) {
            getContext().getResponse().setBody(count);
        } else {
            tryCreate(items[count], callback);
        }
    }
}