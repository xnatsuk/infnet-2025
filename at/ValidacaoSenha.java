import java.util.Scanner;

public class ValidacaoSenha {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        System.out.print("Digite seu nome: ");
        String nome = input.nextLine();

        boolean senhaValida = false;

        while (!senhaValida) {
            System.out.print("Digite uma senha: ");
            String senha = input.nextLine();

            // validação
            boolean temMinimo = senha.length() >= 8;
            boolean temMaiuscula = senha.matches(".*[A-Z].*");
            boolean temNumero = senha.matches(".*\\d.*");
            boolean temEspecial = senha.matches(".*[!@#$%^&*()_+\\-=\\[\\]{};':\"\\\\|,.<>/?].*");

            if (temMinimo && temMaiuscula && temNumero && temEspecial) {
                System.out.println("Cadastro realizado com sucesso.");
                senhaValida = true;
            } else {
                System.out.println("Erro na senha:");
                if (!temMinimo) System.out.println("- A senha deve ter no mínimo 8 caracteres.");
                if (!temMaiuscula) System.out.println("- A senha deve conter pelo menos uma letra maiúscula.");
                if (!temNumero) System.out.println("- A senha deve conter pelo menos um número.");
                if (!temEspecial) System.out.println("- A senha deve conter pelo menos um caractere especial.");
                System.out.println("Tente novamente.");
            }
        }

        input.close();
    }
}
