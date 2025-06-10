package tp3.service;

import tp3.utils.OperationUtils;

import java.net.HttpURLConnection;

public class PostEntity {
    private static final String API_URL = "https://apichallenges.eviltester.com/sim/entities";

    public static void main(String[] args) {
        String payload = """
                         {"name":"aluno"}
                         """;
        String newEntity = postEntity(payload, API_URL);
        String id = OperationUtils.getIdWithRegex(newEntity);

        System.out.println("ID: " + id);
    }

    public static String postEntity(String newEntity, String _url) {
        try {
            HttpURLConnection connection = OperationUtils.setConnection(_url, "POST");
            OperationUtils.sendPayload(connection, newEntity);
            String response = OperationUtils.getFullResponse(connection);

            System.out.println(response);

            connection.disconnect();

            return response;

        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }
}
