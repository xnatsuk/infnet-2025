package tp3.service;

public class PostUpdateEntity {
    private static final String API_URL = "https://apichallenges.eviltester.com/sim/entities/";

    public static void main(String[] args) {
        int id = 10;
        String payload = """
                         {"name":"atualizado"}
                         """;
        String url = API_URL + id;
        GetAllEntities.getAll();
        PostEntity.postEntity(payload, url);

    }
}
