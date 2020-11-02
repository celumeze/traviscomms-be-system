function spBulkDelete(query) {
    

    var collection = getContext().getCollection();
    var collectionLink = collection.getSelfLink();
    var response = getContext().getResponse();
    var responseBody = {
        deleted: 0,
        continuation: true
    };


    if (!query) throw new Error("The query is undefined or null.");
    
    tryQueryAndDelete();

    //Run the query recursively with support for continuation tokens
    // tryDelete(documents) is called as the query return documents
    function tryQueryAndDelete(continuation) {
        var requestOptions = { continuation: continuation, pageSize: 1000000 };

        var isAccepted = collection.queryDocuments(collectionLink, query, requestOptions, function (err, retrievedDocs, responseOptions) {
            if (err) throw err;

            if (retrievedDocs.length > 0) {
                tryDelete(retrievedDocs);
            } else if (responseOptions.continuation) {
                tryQueryAndDelete(responseOptions.continuation)
            } else {
                //if there are no more documents and no continuation
                //token then deleting is done
                responseBody.continuation = false;
                response.setBody(responseBody);
            }
        });

        // if we hot execution bounds -return continuation: true
        if (!isAccepted) {
            response.setBody(responseBody);
        }
    }

    //Recursively delete documents passed in as an array
    function tryDelete(documents) {
        if (documents.length > 0) {
            var requestOptions = { etag: documents[0]._etag };
            //Delete the first document in an array
            var isAccepted = collection.deleteDocument(documents[0]._self, requestOptions, function (err, responseOptions) {
                if (err) throw err;

                responseBody.deleted++;
                documents.shift();
                //delete next document in array
                tryDelete(documents);

            });

            if (!isAccepted) {
                response.setBody(responseBody);
            }            
        }
    }
}