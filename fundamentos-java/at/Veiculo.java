public class Veiculo {
    private final String placa;
    private final String modelo;
    private final int anoFabricacao;
    private double quilometragem;

    public Veiculo(String placa, String modelo, int anoFabricacao, double quilometragem) {
        this.placa = placa;
        this.modelo = modelo;
        this.anoFabricacao = anoFabricacao;
        this.quilometragem = quilometragem;
    }

    public static void main(String[] args) {
        Veiculo toyotaCorolla = new Veiculo("ABC1234", "Toyota Corolla", 2020, 15000);
        Veiculo hondaCivic = new Veiculo("XYZ9876", "Honda Civic", 2022, 5000);

        System.out.println("\nDados iniciais:");
        toyotaCorolla.exibirDetalhes();
        hondaCivic.exibirDetalhes();

        toyotaCorolla.registrarViagem(350.5);
        hondaCivic.registrarViagem(125.75);

        System.out.println("\nApós as viagens:");
        toyotaCorolla.exibirDetalhes();
        hondaCivic.exibirDetalhes();
    }

    public void exibirDetalhes() {
        System.out.printf("""
                        \n----- Veículo -----\
                        
                        Placa: %s\
                        
                        Modelo: %s\
                        
                        Ano de Fabricação: %d\
                        
                        Quilometragem: %.2f km\
                        
                        """,
                this.placa, this.modelo, this.anoFabricacao, this.quilometragem);

    }

    public void registrarViagem(double km) {
        quilometragem += km;
        System.out.printf("\nViagem de %.2f km registrada.", km); // valor formatado

    }
}

