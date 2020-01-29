apk update && apk add --no-cache openssl 

openssl pkcs12 -export -out /var/lib/pfx/cert.pfx -inkey /var/lib/secrets/tls.key -in /var/lib/secrets/tls.crt -passout pass:Passw0rd

echo 'pfx file generated:'
ls /var/lib/pfx