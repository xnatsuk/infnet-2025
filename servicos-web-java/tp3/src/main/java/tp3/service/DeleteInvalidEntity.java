package tp3.service;

public class DeleteInvalidEntity {
    private static final String API_URL = "https://apichallenges.eviltester.com/sim/entities/";

    public static void main(String[] args) {
        int id = 2;

        DeleteEntity.deleteEntity(API_URL, id);
    }
}
