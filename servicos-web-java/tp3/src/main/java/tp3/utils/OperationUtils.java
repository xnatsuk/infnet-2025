package tp3.utils;

import java.io.BufferedReader;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URI;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class OperationUtils {
    public static HttpURLConnection setConnection(String _url, String method) {
        try {
            HttpURLConnection connection = (HttpURLConnection) new URI(_url).toURL().openConnection();
            connection.setRequestMethod(method);
            connection.setRequestProperty("Content-Type", "application/json");
            connection.setRequestProperty("Accept", "application/json");

            if (method.equals("POST") || method.equals("PUT") || method.equals("PATCH"))
                connection.setDoOutput(true);

            return connection;

        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    public static void sendPayload(HttpURLConnection connection, String payload) throws IOException {
        DataOutputStream outputStream = new DataOutputStream(connection.getOutputStream());
        outputStream.writeBytes(payload);
        outputStream.flush();
        outputStream.close();
    }

    public static String getIdWithRegex(String response) {
        Pattern pattern = Pattern.compile("\"[iI][dD]\"\\s*:\\s*(\\d+)", Pattern.CASE_INSENSITIVE);
        Matcher matcher = pattern.matcher(response);

        if (matcher.find()) {
            return matcher.group(1);
        }
        return null;
    }

    public static String getIsbn(String response) {
        Pattern pattern = Pattern.compile("\\b\\d{1,5}-\\d{1,7}-\\d{1,7}-\\d{1,7}-\\d\\b", Pattern.CASE_INSENSITIVE);
        Matcher matcher = pattern.matcher(response);

        if (matcher.find()) {
            return matcher.group();
        }
        return null;
    }

    public static String getFullResponse(HttpURLConnection connection) throws IOException {
        StringBuilder response = new StringBuilder();
        int statusCode = connection.getResponseCode();
        String statusMessage = connection.getResponseMessage();
        BufferedReader reader;
        String line;

        if (statusCode >= 200 && statusCode < 300)
            reader = new BufferedReader(new InputStreamReader(connection.getInputStream()));
        else
            reader = new BufferedReader(new InputStreamReader(connection.getErrorStream()));

        response.append(statusCode)
                .append("::")
                .append(statusMessage)
                .append("\n");

        while ((line = reader.readLine()) != null)
            response.append(line);

        return response.toString();
    }
}
