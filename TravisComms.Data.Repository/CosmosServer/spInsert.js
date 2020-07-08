function spInsert(doc) {
    if (!doc) {
        throw new Error("Documents empty");
    }

    var context = getContext();
    var collection = context.getCollection();
    var collectionLink = collection.getSelfLink();

    var accepted = collection.createDocument(collectionLink, doc, function (err, doc) {
        if (err) {
            throw new Error('Error' + err.message);
        }
        context.getResponse().setBody(doc.id)
    });
    if (!accepted) return;
}