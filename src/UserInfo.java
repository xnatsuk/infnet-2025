import java.util.Scanner;

public class UserInfo {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        System.out.println("Digite seu nome completo: ");
        String nome = input.nextLine();

        System.out.println("Digite sua idade: ");
        int idade = input.nextInt();
        input.nextLine();

        System.out.println("Digite o nome da sua mãe: ");
        String mae = input.nextLine();

        System.out.println("Digite o nome do seu pai: ");
        String pai = input.nextLine();

        System.out.println("--- Informações do Usuário ---");
        System.out.println("Nome: " + nome
                + "\nIdade: " + idade
                + "\nMae: " + mae
                + "\nPai: " + pai);


        int tamanhoNome = nome.length();
        int tamanhoMae = mae.length();
        int tamanhoPai = pai.length();

        if (tamanhoNome > tamanhoMae && tamanhoNome > tamanhoPai) {
            System.out.println("Seu nome tem mais letras que o nome dos seus pais.");
        } else {
            System.out.println("Seu nome é menor que o nome dos seus pais.");
        }

        input.close();
    }

}
