import java.time.LocalDate;
import java.time.temporal.ChronoUnit;
import java.util.Scanner;

public class CalcularDias {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        System.out.println("Ano de nascimento: ");
        int ano = input.nextInt();

        System.out.println("Mês: ");
        int mes = input.nextInt();

        System.out.println("Dia: ");
        int dia = input.nextInt();

        LocalDate localDate = LocalDate.of(ano, mes, dia);
        // Calcula os dias até a data atual
        LocalDate hoje = LocalDate.now();
        // O metodo ja calcula os anos bissextos
        long dias = ChronoUnit.DAYS.between(localDate, hoje);

        System.out.println("Idade em Dias: " + dias);
        input.close();
    }
}
