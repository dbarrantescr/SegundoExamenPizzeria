#!/bin/bash

# Proyectito nube 

apt-get install -y nginx
echo "Generando carga en: "<?php
  $x = 0.0001;
  for ($i = 0; $i <= 1000000; $i++) {
    $x += sqrt($x);
  }
  echo "OK!";
?> $HOSTNAME "!" | sudo tee /var/www/html/index.php
