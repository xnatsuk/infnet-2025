package tp3.service;

import tp3.utils.OperationUtils;

import java.net.HttpURLConnection;

public class GetEntityById {
    private static final String API_URL = "https://apichallenges.eviltester.com/sim/entities/";

    public static void main(String[] args) {
        for (int id = 1; id <= 8; id++) {
            getById(API_URL, id);
        }
    }

    public static void getById(String _url, int id) {
        try {
            String url = _url + id;
            HttpURLConnection connection = OperationUtils.setConnection(url, "GET");
            String response = OperationUtils.getFullResponse(connection);

            System.out.println(response);

            connection.disconnect();

        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }
}


