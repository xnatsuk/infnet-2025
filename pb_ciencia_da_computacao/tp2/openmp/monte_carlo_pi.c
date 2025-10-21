#include <omp.h>
#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <time.h>

double estimate_pi_parallel(long N, int num_threads)
{
  long contador = 0;
  double start_time, end_time;

  omp_set_num_threads(num_threads);

  start_time = omp_get_wtime();

#pragma omp parallel
  {
    unsigned int seed = time(NULL) ^ omp_get_thread_num();
    long local_count = 0;

#pragma omp for
    for (long i = 0; i < N; i++)
    {
      // pontos aleatórios em [0, 1] × [0, 1]
      double x = (double)rand_r(&seed) / RAND_MAX;
      double y = (double)rand_r(&seed) / RAND_MAX;

      if (x * x + y * y <= 1.0)
      {
        local_count++;
      }
    }

#pragma omp atomic
    contador += local_count;
  }

  end_time = omp_get_wtime();

  double pi_estimate = 4.0 * contador / N;

  printf("  Threads:             %d\n", num_threads);
  printf("  Pontos:              %ld\n", N);
  printf("  Dentro do círculo:   %ld\n", contador);
  printf("  π estimado:          %.10f\n", pi_estimate);
  printf("  Erro:                %.10f\n", fabs(M_PI - pi_estimate));
  printf("  Tempo:               %.6f segundos\n", end_time - start_time);

  return end_time - start_time;
}

int main()
{
  printf("\n╔══════════════════════════════════════════════════════════════╗\n");
  printf("║       ESTIMATIVA DE π USANDO MÉTODO MONTE CARLO              ║\n");
  printf("╚══════════════════════════════════════════════════════════════╝\n\n");
  printf("Valor real de π: %.10f\n\n", M_PI);

  long N = 100000000;
  int max_threads = omp_get_max_threads();

  printf("Número de threads disponíveis: %d\n\n", max_threads);
  printf("── PARALELO (1 thread - baseline) ──────────────────────────\n");
  double time_baseline = estimate_pi_parallel(N, 1);

  printf("\n── PARALELO (todos os núcleos - %d threads) ───────────────\n", max_threads);
  double time_parallel = estimate_pi_parallel(N, max_threads);

  return 0;
}
