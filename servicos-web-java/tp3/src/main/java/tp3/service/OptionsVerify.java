package tp3.service;

import tp3.utils.OperationUtils;

import java.net.HttpURLConnection;

public class OptionsVerify {
    private final static String API_URL = "https://apichallenges.eviltester.com/sim/entities";

    public static void main(String[] args) {
        verify(API_URL);
    }

    public static void verify(String _url) {
        try {
            HttpURLConnection connection = OperationUtils.setConnection(_url, "OPTIONS");
            String allowHeader = connection.getHeaderField("Allow");

            System.out.println("Métodos suportados:\n" + allowHeader);

        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }
}
