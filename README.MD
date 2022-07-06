 mayor Antropia = contraseña mas dificil de violar


# Hashing: One wayoperation == > Irreversible

## Secure Hash Family (SHA)

* MD5 => 128 bits o 16 bytes
* SHA-1 => 160 bits
* SHA-2 => SHA-256: 32 bits, SHA-512 64 bits
* SHA-3 => no disponible en .Net


# Encryption: Two way operation < == > Reversible
key is needed

# Secure Password Encryption

## Salt

Palabra random que se agrega a la contraseña antes de cifrarla, agregando
entropia. Recomendado de 64 bits u 8 bytes

## PBKDF2: Pasword based key derivation function
password + salt + numero de interaciones (100.000 recomendado)


# Cifrado simetrico

proceso bi direccional utilizando una clave para cifrar y luego decifrar


## Advanced Encryption Standard (AES)

 -> 128 (10 rondas), 192 (12 rondas), 256(14 rondas) bit key



# Asymmetric Encryption => RSA

keys: 1024-bit 2048-bit 4096-bit

- Public Key 
- Private Key => solo el destinatario la conoce

1- A recibe clave publica
2- A encrita los datos usando esa clave publica
3- A mando los datos encriptados
4- B desencripta usando la clave privada
 

devuelvo el contenido cifrado, y la palabra secreta cifrada

el que lo recibe usa la clave privada para decifrar la palabra secreta
y con la palabra secreta descifra el mensaje



# Digital Signature => se basa en RSA

- public and private key generation
- signing algorithm using the private key
- verification algorithm using the public key

Funcionan al reves:
Public key => Verify signature
private key => sign message


# Hybrid


# Security Concepts

## Confidentiality => AES + RSA

Cifrar mensaje o algunos datos para que sean ilegibles

## Integrity => MD5 family: SHA-256

Mantener y garantizar la precision y coherencia de los datos durante
todo su ciclo de vida. Los datos no se pueden modificar de forma
no autorizada.

## Non-repudiation => Digital Signatures

Es la seguridad de que alguien no puede negar algo. Significa que 
no se puede negar la autentidicidad de una firma en un documento
por ejemplo

## Authentication => HMAC SHA-256

ASegurarse que solo una persona autorizada pueda realizar una operacion

https://app.pluralsight.com/library/courses/dotnet-cryptography-secure-applications/table-of-contents

https://github.com/stephenhaunts/Building-Secure-Applications-with-Cryptography-in-.NET-Course-Source-Code
 