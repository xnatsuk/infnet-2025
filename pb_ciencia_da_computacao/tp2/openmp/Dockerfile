FROM gcc:latest

RUN apt-get update && apt-get install -y \
  build-essential \
  libgomp1 \
  vim \
  time \
  && rm -rf /var/lib/apt/lists/*

RUN gcc --version && \
  echo "Checking OpenMP support:" && \
  echo |cpp -fopenmp -dM |grep -i open || true

WORKDIR /workspace

ENV OMP_NUM_THREADS=8

CMD ["/bin/bash"]
