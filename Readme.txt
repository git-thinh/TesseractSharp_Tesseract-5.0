

.NET Wrapper for tessaract v5.0.0.20190623

--------------------------------------
tesseract.patch

diff --git a/ports/tesseract/portfile.cmake b/ports/tesseract/portfile.cmake
index 08f581cfe..9d23e666e 100644
--- a/ports/tesseract/portfile.cmake
+++ b/ports/tesseract/portfile.cmake
@@ -4,9 +4,9 @@ vcpkg_check_linkage(ONLY_STATIC_LIBRARY)
 
 vcpkg_from_github(
     OUT_SOURCE_PATH SOURCE_PATH
-    REPO tesseract-ocr/tesseract
-    REF 4.1.0
-    SHA512 d617f5c5b826640b2871dbe3d7973bcc5e66fafd837921a20e009d683806ed50f0f258aa455019d99fc54f5cb65c2fa0380e3a3c92b39ab0684b8799c730b09d
+    REPO UB-Mannheim/tesseract
+    REF v5.0.0.20190623
+    SHA512 6ba6a5a229ee99fefcea836b883c80583e8265473ae6f599b40c37c4792f28f698abd17e311cea91cd218c0cf958d2202e158bcfe1a8022779834ccc3be04799
     PATCHES
         fix-tiff-linkage.patch
         fix-text2image.patch

