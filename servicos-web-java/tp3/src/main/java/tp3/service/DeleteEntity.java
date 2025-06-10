package tp3.service;

import tp3.utils.OperationUtils;

import java.net.HttpURLConnection;

public class DeleteEntity {
    private static final String API_URL = "https://apichallenges.eviltester.com/sim/entities/";

    public static void main(String[] args) {
        int id = 9;

        deleteEntity(API_URL, id);
        GetEntityById.getById(API_URL, id);
    }

    public static void deleteEntity(String _url, int id) {
        try {
            String url = _url + id;
            HttpURLConnection connection = OperationUtils.setConnection(url, "DELETE");
            String response = OperationUtils.getFullResponse(connection);

            System.out.println(response);

            connection.disconnect();

        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }
}
