��    f      L  �   |      �     �  9   �     �     	  +    	     L	  )   \	  )   �	  )   �	     �	  )   �	  )   !
  +   K
  )   w
  R   �
  )   �
  )        H  U   e  A   �  )   �  )   '  )   Q  ,   {  )   �  )   �  )   �  )   &  )   P  )   z  )   �  )   �  )   �  )   "  )   L  )   v  )   �  )   �  )   �  )     )   H  )   r     �  )   �  )   �  )     )   1  	   [  )   e  �   �  &   0  !   W  )   y     �  ,   �  *   �  A        T     a     j  @   �  '   �  &   �  "     1   :     l  7   �  +   �  !   �  (        :  ,   W  :   �  !   �     �  0   �  8   /     h  "   �     �     �     �     �     �  &   �  +   %  )   Q     {     �  -   �  )   �     �  ;   �  =   2  �   p  )     /   7  B   g  (   �     �  	   �  �  �     �  C   �     8     R  ;   i     �  5   �  4   �  7   #  !   [  6   }  5   �  1   �  4     `   Q  5   �  5   �  !     f   @  S   �  5   �  5   1  5   g  8   �  5   �  5      5   B   5   x   5   �   5   �   5   !  5   P!  5   �!  7   �!  5   �!  5   *"  5   `"  )   �"  )   �"  )   �"  )   #  )   >#     h#  )   �#  )   �#  )   �#  )    $  
   *$  5   5$  �   k$  0   $%  !   U%  5   w%  !   �%  3   �%  1   &  G   5&     }&  	   �&  .   �&  N   �&  2   '  +   G'  )   s'  ;   �'  '   �'  N   (  <   P(  )   �(  0   �(  &   �(  :   )  E   J)  (   �)  %   �)  9   �)  H   *  )   b*  3   �*     �*     �*     �*  '   �*      +  -   ,+  5   Z+  )   �+  #   �+     �+  :   �+  )   %,     O,  G   X,  N   �,  �   �,  6   �-  E   �-  >   1.  6   p.      �.     �.     T   R      
      8      "       Z   S      6          .   L   e   5      -                        O   D           U   *       ^      W   %   E   f           0                    N          b   4   a       F                     [      (   :   #       G          1   d          7      )                     J   P       H   M   /   K   +           3   ,       X   <   C   Y   ]      V   A          I   @   '   2          _   \   !   >   =   &              ?           Q       9      	   B      `   ;   c           $    

Values to be changed:

 
If these values seem acceptable, use -f to force reset.
 
Report bugs to <%s>.
 %s home page: <%s>
 %s resets the PostgreSQL write-ahead log.

 64-bit integers Blocks per segment of large relation: %u
 Bytes per WAL segment:                %u
 Catalog version number:               %u
 Current pg_control values:

 Data page checksum version:           %u
 Database block size:                  %u
 Database system identifier:           %llu
 Date/time type storage:               %s
 File "%s" contains "%s", which is not compatible with this program's version "%s". First log segment after reset:        %s
 Float8 argument passing:              %s
 Guessed pg_control values:

 If you are sure the data directory path is correct, execute
  touch %s
and try again. Is a server running?  If not, delete the lock file and try again. Latest checkpoint's NextMultiOffset:  %u
 Latest checkpoint's NextMultiXactId:  %u
 Latest checkpoint's NextOID:          %u
 Latest checkpoint's NextXID:          %u:%u
 Latest checkpoint's TimeLineID:       %u
 Latest checkpoint's full_page_writes: %s
 Latest checkpoint's newestCommitTsXid:%u
 Latest checkpoint's oldestActiveXID:  %u
 Latest checkpoint's oldestCommitTsXid:%u
 Latest checkpoint's oldestMulti's DB: %u
 Latest checkpoint's oldestMultiXid:   %u
 Latest checkpoint's oldestXID's DB:   %u
 Latest checkpoint's oldestXID:        %u
 Maximum columns in an index:          %u
 Maximum data alignment:               %u
 Maximum length of identifiers:        %u
 Maximum size of a TOAST chunk:        %u
 NextMultiOffset:                      %u
 NextMultiXactId:                      %u
 NextOID:                              %u
 NextXID epoch:                        %u
 NextXID:                              %u
 OID (-o) must not be 0 OldestMulti's DB:                     %u
 OldestMultiXid:                       %u
 OldestXID's DB:                       %u
 OldestXID:                            %u
 Options:
 Size of a large-object chunk:         %u
 The database server was not shut down cleanly.
Resetting the write-ahead log might cause data to be lost.
If you want to proceed anyway, use -f to force reset.
 Try "%s --help" for more information.
 Usage:
  %s [OPTION]... DATADIR

 WAL block size:                       %u
 Write-ahead log reset
 You must run %s as the PostgreSQL superuser. argument of --wal-segsize must be a number argument of --wal-segsize must be a power of 2 between 1 and 1024 by reference by value cannot be executed by "root" cannot create restricted tokens on this platform: error code %lu could not allocate SIDs: error code %lu could not change directory to "%s": %m could not close directory "%s": %m could not create restricted token: error code %lu could not delete file "%s": %m could not get exit code from subprocess: error code %lu could not load library "%s": error code %lu could not open directory "%s": %m could not open file "%s" for reading: %m could not open file "%s": %m could not open process token: error code %lu could not re-execute with restricted token: error code %lu could not read directory "%s": %m could not read file "%s": %m could not read permissions of directory "%s": %m could not start process for command "%s": error code %lu could not write file "%s": %m data directory is of wrong version error:  fatal:  fsync error: %m invalid argument for option %s lock file "%s" exists multitransaction ID (-m) must not be 0 multitransaction offset (-O) must not be -1 newestCommitTsXid:                    %u
 no data directory specified off oldest multitransaction ID (-m) must not be 0 oldestCommitTsXid:                    %u
 on pg_control exists but has invalid CRC; proceed with caution pg_control exists but is broken or wrong version; ignoring it pg_control specifies invalid WAL segment size (%d byte); proceed with caution pg_control specifies invalid WAL segment size (%d bytes); proceed with caution pg_control version number:            %u
 too many command-line arguments (first is "%s") transaction ID (-c) must be either 0 or greater than or equal to 2 transaction ID epoch (-e) must not be -1 unexpected empty file "%s" warning:  Project-Id-Version: pg_resetwal (PostgreSQL) 14
Report-Msgid-Bugs-To: pgsql-bugs@lists.postgresql.org
POT-Creation-Date: 2021-08-03 16:47+0000
PO-Revision-Date: 2019-06-06 17:24-0400
Last-Translator: Carlos Chapi <carlos.chapi@2ndquadrant.com>
Language-Team: PgSQL-es-Ayuda <pgsql-es-ayuda@lists.postgresql.org>
Language: es
MIME-Version: 1.0
Content-Type: text/plain; charset=UTF-8
Content-Transfer-Encoding: 8bit
X-Generator: Poedit 2.0.2
Plural-Forms: nplurals=2; plural=(n != 1);
 

Valores a cambiar:

 
Si estos valores parecen aceptables, use -f para forzar reinicio.
 
Reporte errores a <%s>.
 Sitio web de %s: <%s>
 %s restablece el WAL («write-ahead log») de PostgreSQL.

 enteros de 64 bits Bloques por segmento de relación grande:         %u
 Bytes por segmento WAL:                          %u
 Número de versión de catálogo:                   %u
 Valores actuales de pg_control:

 Versión de suma de verificación de datos:        %u
 Tamaño del bloque de la base de datos:           %u
 Identificador de sistema:                   %llu
 Tipo de almacenamiento hora/fecha:               %s
 El archivo «%s» contiene «%s», que no es compatible con la versión «%s» de este programa. Primer segmento de log después de reiniciar:     %s
 Paso de parámetros float8:                       %s
 Valores de pg_control asumidos:

 Si está seguro que la ruta al directorio de datos es correcta, ejecute
   touch %s
y pruebe de nuevo. ¿Hay un servidor corriendo? Si no, borre el archivo candado e inténtelo de nuevo. NextMultiOffset del checkpoint más reciente:     %u
 NextMultiXactId del checkpoint más reciente:     %u
 NextOID del checkpoint más reciente:             %u
 NextXID del checkpoint más reciente:             %u:%u
 TimeLineID del checkpoint más reciente:          %u
 full_page_writes del checkpoint más reciente:    %s
 newestCommitTsXid del último checkpoint:         %u
 oldestActiveXID del checkpoint más reciente:     %u
 oldestCommitTsXid del último checkpoint:         %u
 BD del oldestMultiXid del checkpt. más reciente: %u
 oldestMultiXid del checkpoint más reciente:      %u
 BD del oldestXID del checkpoint más reciente:    %u
 oldestXID del checkpoint más reciente:           %u
 Máximo número de columnas en un índice:          %u
 Máximo alineamiento de datos:                    %u
 Longitud máxima de identificadores:              %u
 Longitud máxima de un trozo TOAST:               %u
 NextMultiOffset:                      %u
 NextMultiXactId:                      %u
 NextOID:                              %u
 Epoch del NextXID:                    %u
 NextXID:                              %u
 OID (-o) no debe ser cero Base de datos del OldestMulti:        %u
 OldestMultiXid:                       %u
 Base de datos del OldestXID:          %u
 OldestXID:                            %u
 Opciones:
 Longitud máxima de un trozo de objeto grande:    %u
 El servidor de bases de datos no se apagó limpiamente.
Restablecer el WAL puede causar pérdida de datos.
Si quiere continuar de todas formas, use -f para forzar el restablecimiento.
 Prueba con «%s --help» para más información
 Uso:
   %s [OPCIÓN]... DATADIR

 Tamaño del bloque de WAL:                        %u
 «Write-ahead log» restablecido
 Debe ejecutar %s con el superusuario de PostgreSQL. el argumento de --wal-segsize debe ser un número el argumento de --wal-segsize debe ser una potencia de 2 entre 1 y 1024 por referencia por valor no puede ser ejecutado con el usuario «root» no se pueden crear tokens restrigidos en esta plataforma: código de error %lu no se pudo emplazar los SIDs: código de error %lu no se pudo cambiar al directorio «%s»: %m no se pudo abrir el directorio «%s»: %m no se pudo crear el token restringido: código de error %lu no se pudo borrar el archivo «%s»: %m no se pudo obtener el código de salida del subproceso»: código de error %lu no se pudo cargar la biblioteca «%s»: código de error %lu no se pudo abrir el directorio «%s»: %m no se pudo abrir archivo «%s» para lectura: %m no se pudo abrir el archivo «%s»: %m no se pudo abrir el token de proceso: código de error %lu no se pudo re-ejecutar con el token restringido: código de error %lu no se pudo leer el directorio «%s»: %m no se pudo leer el archivo «%s»: %m no se pudo obtener los permisos del directorio «%s»: %m no se pudo iniciar el proceso para la orden «%s»: código de error %lu no se pudo escribir el archivo «%s»: %m el directorio de datos tiene la versión equivocada error:  fatal:  error de fsync: %m argumento no válido para la opción %s el archivo candado «%s» existe el ID de multitransacción (-m) no debe ser 0 la posición de multitransacción (-O) no debe ser -1 newestCommitTsXid:                    %u
 directorio de datos no especificado desactivado el ID de multitransacción más antiguo (-m) no debe ser 0 oldestCommitTsXid:                    %u
 activado existe pg_control pero tiene un CRC no válido, proceda con precaución existe pg_control pero está roto o tiene la versión equivocada; ignorándolo pg_control especifica un tamaño de segmento de WAL no válido (%d byte), proceda con precaución pg_control especifica un tamaño de segmento de WAL no válido (%d bytes), proceda con precaución Número de versión de pg_control:                 %u
 demasiados argumentos en la línea de órdenes (el primero es «%s») el ID de transacción (-c) debe ser 0 o bien mayor o igual a 2 el «epoch» de ID de transacción (-e) no debe ser -1 archivo vacío inesperado «%s» precaución:  