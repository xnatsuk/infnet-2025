package tp3.service;

import tp3.utils.OperationUtils;

import java.net.HttpURLConnection;
import java.net.URLEncoder;
import java.nio.charset.StandardCharsets;
import java.util.HashMap;
import java.util.Map;

public class GetWithParameters {
    private static final String API_URL = "https://apichallenges.eviltester.com/sim/entities?";

    public static void main(String[] args) {
        Map<String, String> params = new HashMap<>();
        params.put("categoria", "teste");
        params.put("limite", "5");

        getEntity(setUrlParameters(params));
    }

    public static void getEntity(String params) {
        try {
            String url = API_URL + params;
            HttpURLConnection connection = OperationUtils.setConnection(url, "GET");
            String response = OperationUtils.getFullResponse(connection);

            System.out.println("URL Final = " + url);
            System.out.println(response);

            connection.disconnect();

        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    private static String setUrlParameters(Map<String, String> params) {
        StringBuilder result = new StringBuilder();
        for (Map.Entry<String, String> entry : params.entrySet()) {
            if (!result.isEmpty()) result.append("&");
            result.append(URLEncoder.encode(entry.getKey(), StandardCharsets.UTF_8))
                  .append("=")
                  .append(URLEncoder.encode(entry.getValue(), StandardCharsets.UTF_8));
        }

        return result.toString();
    }

}
