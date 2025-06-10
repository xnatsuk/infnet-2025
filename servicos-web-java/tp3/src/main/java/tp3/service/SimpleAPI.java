package tp3.service;

import tp3.utils.OperationUtils;

import java.net.HttpURLConnection;

public class SimpleAPI {
    private static final String ISBN_URL = "https://apichallenges.eviltester.com/simpleapi/randomisbn";
    private static final String ITEMS_URL = "https://apichallenges.eviltester.com/simpleapi/items";

    public static void main(String[] args) {
        getAllItems(ITEMS_URL);

        String responseWithIsbn = getRandomISBN(ISBN_URL);


        String isbn = OperationUtils.getIsbn(responseWithIsbn);
        String payload = """
                         {
                         "type": "book",
                         "isbn13": "%s",
                         "price": 5.99,
                         "numberinstock": 5
                         }
                         """.formatted(isbn);

        String newItem = createItem(ITEMS_URL, payload);
        String itemID = OperationUtils.getIdWithRegex(newItem);

        System.out.println("\nNovo Item:\n" + newItem);
        System.out.println("\nItem ID: " + itemID);

        String updatePayload = """
                               {
                               "type": "book",
                               "isbn13": "%s",
                               "price": 9.99,
                               "numberinstock": 0
                               }
                               """.formatted(isbn);

        String updatedItem = updateItem(ITEMS_URL, updatePayload, itemID);
        System.out.println("\nItem Atualizado:\n" + updatedItem);

        deleteItem(ITEMS_URL, itemID);
        getItem(ITEMS_URL, itemID);
        System.out.println("Item Deletado!");

    }

    public static void getAllItems(String url) {
        try {
            HttpURLConnection connection = OperationUtils.setConnection(url, "GET");
            String response = OperationUtils.getFullResponse(connection);

            System.out.println(response);

            connection.disconnect();

        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    public static String getRandomISBN(String url) {
        try {
            HttpURLConnection connection = OperationUtils.setConnection(url, "GET");

            return OperationUtils.getFullResponse(connection);

        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    public static String createItem(String _url, String payload) {
        try {
            HttpURLConnection connection = OperationUtils.setConnection(_url, "POST");
            OperationUtils.sendPayload(connection, payload);

            return OperationUtils.getFullResponse(connection);

        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    public static String updateItem(String _url, String payload, String id) {
        try {
            HttpURLConnection connection = OperationUtils.setConnection(_url + "/" + id, "PUT");
            OperationUtils.sendPayload(connection, payload);

            return OperationUtils.getFullResponse(connection);

        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    public static void deleteItem(String _url, String id) {
        try {
            HttpURLConnection connection = OperationUtils.setConnection(_url + "/" + id, "DELETE");

            System.out.println(OperationUtils.getFullResponse(connection));

        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    public static void getItem(String _url, String id) {
        try {
            HttpURLConnection connection = OperationUtils.setConnection(_url + "/" + id, "GET");

            System.out.println(OperationUtils.getFullResponse(connection));

        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }
}
