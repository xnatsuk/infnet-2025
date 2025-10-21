CC = gcc
CFLAGS = -fopenmp -O3 -Wall
LDFLAGS = -lm

all:  monte_carlo_pi

monte_carlo_pi: monte_carlo_pi.c
	$(CC) $(CFLAGS) -o monte_carlo_pi monte_carlo_pi.c $(LDFLAGS)

test: all
	@echo "Executando Monte Carlo Pi"
	./monte_carlo_pi

clean:
	rm -f monte_carlo_pi *.o

.PHONY: all test clean
