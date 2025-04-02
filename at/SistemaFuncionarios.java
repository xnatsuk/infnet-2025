public class SistemaFuncionarios {
    public static void main(String[] args) {
        System.out.println("------ Sistema de Funcionários ------");

        Gerente gerente = new Gerente("Christian", 12600);
        Estagiario estagiario = new Estagiario("Marcos", 2100);

        gerente.exibirDados();
        estagiario.exibirDados();
    }
}

class Funcionario {
    String nome;
    double salarioBase;

    public Funcionario(String nome, double salarioBase) {
        this.nome = nome;
        this.salarioBase = salarioBase;
    }

    public double calcularSalario() {
        return salarioBase;
    }

    public void exibirDados() {
        System.out.printf("""
                        Nome: %s\
                        
                        Salário Base: R$ %.2f\
                        
                        Salário Final: R$ %.2f\
                        
                        """,
                this.nome, this.salarioBase, calcularSalario());

    }
}

class Gerente extends Funcionario {
    public Gerente(String nome, double salarioBase) {
        super(nome, salarioBase);
    }

    @Override
    public double calcularSalario() {
        return salarioBase * 1.2; // bônus de 20%
    }

    @Override
    public void exibirDados() {
        System.out.println("\n------ Dados do Gerente ------");
        super.exibirDados();
        System.out.println("Bônus: 20%");
    }
}

class Estagiario extends Funcionario {
    public Estagiario(String nome, double salarioBase) {
        super(nome, salarioBase);
    }

    @Override
    public double calcularSalario() {
        return salarioBase * 0.9; //desconto de 10%
    }

    @Override
    public void exibirDados() {
        System.out.println("\n------ Dados do Estagiário ------");
        super.exibirDados();
        System.out.println("Desconto: 10%");
    }
}


