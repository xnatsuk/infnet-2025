package tp3.service;

import tp3.utils.OperationUtils;

import java.net.HttpURLConnection;

public class GetAllEntities {
    private static final String API_URL = "https://apichallenges.eviltester.com/sim/entities";

    public static void main(String[] args) {
        getAll();
    }

    public static void getAll() {
        try {
            HttpURLConnection connection = OperationUtils.setConnection(API_URL, "GET");
            String response = OperationUtils.getFullResponse(connection);

            System.out.println(response);

            connection.disconnect();

        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }
}
