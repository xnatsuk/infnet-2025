package tp3.service;

public class GetNonexistentEntity {
    private static final String API_URL = "https://apichallenges.eviltester.com/sim/entities/";

    public static void main(String[] args) {
        int id = 15;
        GetEntityById.getById(API_URL, id);
    }
}
