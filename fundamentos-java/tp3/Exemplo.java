class Exemplo {
    public static void main(String[] args) {
        Roedor capivara = new Roedor();
        // valores iniciais
        capivara.especie = "Capivara";
        capivara.nome = "Carlos";
        capivara.idadeMeses = 17;

        int idade = capivara.getIdade();
        capivara.setNome("Rodolfo");
        System.out.println(capivara.especie + " " + capivara.nome + " possui " + idade + " meses");
    }
}

class Roedor {
    String especie;
    String nome;
    int idadeMeses;


    int getIdade() {
        return idadeMeses;
    }

    void setNome(String nome) {
        this.nome = nome;
    }
}
