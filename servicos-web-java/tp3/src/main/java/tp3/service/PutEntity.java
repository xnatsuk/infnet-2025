package tp3.service;

import tp3.utils.OperationUtils;

import java.net.HttpURLConnection;

public class PutEntity {
    private static final String API_URL = "https://apichallenges.eviltester.com/sim/entities/";

    public static void main(String[] args) {
        int id = 10;
        String payload = """
                         {"name":"atualizado"}
                         """;
        String url = API_URL + id;

        putEntity(payload, url);
        GetAllEntities.getAll();

    }

    public static void putEntity(String entity, String _url) {
        try {
            HttpURLConnection connection = OperationUtils.setConnection(_url, "PUT");
            OperationUtils.sendPayload(connection, entity);
            String response = OperationUtils.getFullResponse(connection);

            System.out.println(response);

            connection.disconnect();

        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }
}
