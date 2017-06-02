<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt"
    xmlns:utilityExtension="pdfprinter:extensions:utility"
    exclude-result-prefixes="msxsl utilityExtension">
  <xsl:output method="xml" indent="yes" omit-xml-declaration="yes" encoding="utf-8"/>
  <xsl:template match="/">
    <xsl:variable name="logo" select="utilityExtension:MapPath('~/App_Data/Resources/IMAGES/EscudoMDS.png')"/>
    <fo:root xmlns:fo="http://www.w3.org/1999/XSL/Format">
      <fo:layout-master-set>
        <fo:simple-page-master master-name="simple"
                      page-height="29.7cm"
                      page-width="21cm"
                      margin-top="0.5cm"
                      margin-bottom="0.5cm"
                      margin-left="2cm"
                      margin-right="2cm">
          <fo:region-body margin-top="3.5cm" margin-bottom="4cm"/>
          <fo:region-before extent="7cm"/>
          <!-- Header -->
          <fo:region-after extent="3cm"/>
          <!-- Footer -->
        </fo:simple-page-master>
      </fo:layout-master-set>
      <fo:page-sequence master-reference="simple">
        <fo:static-content flow-name="xsl-region-before" >
          <!-- tabla cabecera -->
          <fo:block>
            <fo:external-graphic src="url('{$logo}')" content-width="auto" content-height="auto"/>
          </fo:block>
          <fo:block padding="5pt">
            <fo:table border-collapse="collapse" table-layout="fixed">
              <fo:table-column column-width="5.5cm" column-number="1"/>
              <fo:table-column column-width="5.5cm" column-number="2"/>
              <fo:table-column column-width="5.5cm" column-number="3"/>
              <fo:table-body>
                <fo:table-row>
                  <fo:table-cell border-width="0.5pt" border-style="solid" text-align="center" padding="2pt">
                    <fo:block text-align="center" font-size="7pt">
                      SISTEMA NACIONAL DE LA PROFESION ADMINISTRATIVA - DECRETO Nº 993/91
                    </fo:block>
                    <fo:block text-align="center" font-size="7pt" padding-top="0.5cm">
                      SISTEMA DE EVALUACION DE DESEMPEÑO
                    </fo:block>
                  </fo:table-cell>
                  <fo:table-cell border-width="0.5pt" border-style="solid" text-align="center" padding="2pt">
                    <fo:block>FORMULARIO DE EVALUACION DE DESEMPEÑO</fo:block>
                  </fo:table-cell>
                  <fo:table-cell border-width="0.5pt" border-style="solid" text-align="center" padding="2pt">
                    <fo:block font-size="18pt">
                      <!--||||||||||||| codigo de barras-->
                    </fo:block>
                  </fo:table-cell>
                </fo:table-row>
                <fo:table-row>
                  <fo:table-cell>
                    <fo:block/>
                  </fo:table-cell>
                  <fo:table-cell border-width="0.5pt" border-style="solid" number-columns-spanned="2" padding="2pt">
                    <fo:block text-align="left" font-weight="bold" font-size="8pt">
                      <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/agente_y_periodo_en_cabecera"/>
                      { Hoja
                      <fo:page-number/>
                      de
                      <fo:page-number-citation ref-id="last-page"/>
                      }
                    </fo:block>
                  </fo:table-cell>
                </fo:table-row>
              </fo:table-body>
            </fo:table>
          </fo:block>
          <!--fin tabla cabecera-->
        </fo:static-content>
        <fo:flow flow-name="xsl-region-body" font-family="Helvetica" font-size="11pt">
          <fo:block>
            <fo:block padding-top="2pt">
              <fo:block text-align="center" padding-top="1cm">
                <fo:leader />
                <!--tabla nivel -->
                <fo:table border-collapse="collapse" table-layout="fixed">
                  <fo:table-column column-width="16.5cm" column-number="1"/>
                  <fo:table-body>
                    <fo:table-row>
                      <fo:table-cell border-width="0.5pt" border-style="solid" text-align="left" padding="2pt">
                        <fo:block >
                          <fo:inline text-align="left" font-size="7pt" font-weight="bold">
                            <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/nivel_negrita"/>:
                          </fo:inline>
                          <fo:inline text-align="left" font-size="7pt">
                            <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/descripcion_larga_nivel"/>
                          </fo:inline>
                        </fo:block>
                      </fo:table-cell>
                    </fo:table-row>
                  </fo:table-body>
                </fo:table>
                <!--fin tabla nivel -->
                <fo:leader />
                <!--tabla organismo-->
                <fo:table border-collapse="collapse" table-layout="fixed">
                  <fo:table-column column-width="8.25cm" column-number="1"/>
                  <fo:table-column column-width="8.25cm" column-number="2"/>
                  <fo:table-body>
                    <fo:table-row>
                      <fo:table-cell border-width="0.5pt" border-style="solid" text-align="left" padding="2pt" number-columns-spanned="2" >
                        <fo:block font-size="7pt" font-weight="bold">
                          IDENTIFICACION DEL ORGANISMO en el que revista según estructura:
                        </fo:block>
                      </fo:table-cell>
                    </fo:table-row>
                    <fo:table-row >
                      <fo:table-cell border-width="0.5pt" border-style="solid" text-align="left" padding="2pt" number-rows-spanned="2" >
                        <fo:block >
                          <fo:inline text-align="left" font-size="7pt">
                            Jurisdicción / Org. Descentralizado:
                          </fo:inline>
                          <fo:inline text-align="left" font-size="7pt" font-weight="bold">
                            <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/jurisdiccion"/>
                          </fo:inline>
                        </fo:block>
                        <fo:block>
                          <fo:inline text-align="left" font-size="7pt">
                            Secretaria:
                          </fo:inline>
                          <fo:inline text-align="left" font-size="7pt" font-weight="bold">
                            <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/secretaria"/>
                          </fo:inline>
                        </fo:block>
                        <fo:block>
                          <fo:inline text-align="left" font-size="7pt">
                            Subsecretaria:
                          </fo:inline>
                          <fo:inline text-align="left" font-size="7pt" font-weight="bold">
                            <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/sub_secretaria"/>
                          </fo:inline>
                        </fo:block>
                        <fo:block>
                          <fo:inline text-align="left" font-size="7pt">
                            Dirección Nacional o General:
                          </fo:inline>
                          <fo:inline text-align="left" font-size="7pt" font-weight="bold">
                            <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/direccion"/>
                          </fo:inline>
                        </fo:block>
                        <fo:block>
                          <fo:inline text-align="left" font-size="7pt">
                            Unidad:
                          </fo:inline>
                          <fo:inline text-align="left" font-size="7pt" font-weight="bold">
                            <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/unidad"/>
                          </fo:inline>
                        </fo:block>
                      </fo:table-cell>
                      <fo:table-cell border-width="0.5pt" border-style="solid"  padding="2pt" text-align="left">
                        <fo:block text-align="left" font-size="7pt" font-weight="bold">
                          * Para casos en que el agente presente servicios en otra Unidad de Evaluacion diferente a la de revista:
                        </fo:block>
                        <fo:block>
                          <fo:inline text-align="left" font-size="7pt">
                            Unidad de Evaluación:
                          </fo:inline>
                          <fo:inline text-align="left" font-size="7pt" font-weight="bold">
                            <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/unidad_evaluacion"/>
                          </fo:inline>
                        </fo:block>
                        <fo:block>
                          <fo:inline text-align="left" font-size="7pt">
                            Código Unidad de Evaluación:
                          </fo:inline>
                          <fo:inline text-align="left" font-size="7pt" font-weight="bold">
                            <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/codigo_unidad_evaluacion"/>
                          </fo:inline>
                        </fo:block>
                      </fo:table-cell>
                    </fo:table-row>
                    <fo:table-row>
                      <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt" >
                        <fo:block text-align="left" font-size="7pt">
                          Período Evaluado:
                        </fo:block>
                        <fo:block text-align="center" font-size="11pt" font-weight="bold">
                          <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/periodo_evaluado"/>
                        </fo:block>
                      </fo:table-cell>
                    </fo:table-row>
                  </fo:table-body>
                </fo:table>
                <!--fin tabla organismo-->
                <fo:leader />
                <!--tabla agente evaluador y evaluado-->
                <fo:table>
                  <fo:table-column column-width="8.25cm" column-number="1"/>
                  <fo:table-column column-width="8.25cm" column-number="2"/>
                  <fo:table-body>
                    <fo:table-row >
                      <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt">
                        <fo:block  text-align="left" font-size="7pt" font-weight="bold">
                          IDENTIFICACION DEL EVALUADOR
                        </fo:block>
                      </fo:table-cell>
                      <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt" text-align="left">
                        <fo:block text-align="left" font-size="7pt" font-weight="bold">
                          IDENTIFICACION DEL AGENTE
                        </fo:block>
                      </fo:table-cell>
                    </fo:table-row>
                    <fo:table-row>
                      <!--  evaluador -->
                      <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt" text-align="left">
                        <fo:block>
                          <fo:block >
                            <fo:inline text-align="left" font-size="7pt">
                              Apellido y Nombre:
                            </fo:inline>
                            <fo:inline text-align="left" font-size="7pt" font-weight="bold">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/apellido_y_nombre_evaluador"/>
                            </fo:inline>
                          </fo:block>
                          <fo:block>
                            <fo:inline text-align="left" font-size="7pt">
                              Documento de Identidad:
                            </fo:inline>
                            <fo:inline text-align="left" font-size="7pt" font-weight="bold">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/documento_evaluador"/>
                            </fo:inline>
                          </fo:block>
                          <fo:block>
                            <fo:inline text-align="left" font-size="7pt">
                              Situacion Escalafonaria:
                            </fo:inline>
                            <fo:inline text-align="left" font-size="7pt" font-weight="bold">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/situacion_escalafonaria_evaluador"/>
                            </fo:inline>
                          </fo:block>
                          <fo:block>
                            <fo:inline text-align="left" font-size="7pt">
                              De pertenecer a SINAPA:
                            </fo:inline>
                          </fo:block>
                          <fo:block>
                            <fo:inline text-align="left" font-size="7pt">
                              &#x00A0;&#x00A0;&#x00A0;
                            </fo:inline>
                            <fo:inline text-align="left" font-size="7pt">
                              Nivel:
                            </fo:inline>
                            <fo:inline text-align="left" font-size="7pt" font-weight="bold">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/nivel_evaluador"/>
                            </fo:inline>
                            <fo:inline text-align="left" font-size="7pt">
                              Grado:
                            </fo:inline>
                            <fo:inline text-align="left" font-size="7pt" font-weight="bold">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/grado_evaluador"/>
                            </fo:inline>
                            <fo:inline text-align="left" font-size="7pt">
                              Agrupamiento:
                            </fo:inline>
                            <fo:inline text-align="left" font-size="7pt" font-weight="bold">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/agrupamiento_evaluador"/>
                            </fo:inline>
                          </fo:block>
                          <fo:block>
                            <fo:inline text-align="left" font-size="7pt">
                              Puesto o Cargo que ocupa:
                            </fo:inline>
                            <fo:inline text-align="left" font-size="7pt" font-weight="bold">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/puesto_evaluador"/>
                            </fo:inline>
                          </fo:block>
                        </fo:block>
                      </fo:table-cell>
                      <!--  fin evaluador -->
                      <!--  evaluado -->
                      <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt" text-align="left">
                        <fo:block>
                          <fo:block >
                            <fo:inline text-align="left" font-size="7pt">
                              Apellido y Nombre:
                            </fo:inline>
                            <fo:inline text-align="left" font-size="7pt" font-weight="bold">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/apellido_y_nombre_evaluado"/>
                            </fo:inline>
                          </fo:block>
                          <fo:block>
                            <fo:inline text-align="left" font-size="7pt">
                              Documento de Identidad:
                            </fo:inline>
                            <fo:inline text-align="left" font-size="7pt" font-weight="bold">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/documento_evaluado"/>
                            </fo:inline>
                          </fo:block>
                          <fo:block>
                            <fo:inline text-align="left" font-size="7pt">
                              Legajo:
                            </fo:inline>
                            <fo:inline text-align="left" font-size="7pt" font-weight="bold">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/legajo_evaluado"/>
                            </fo:inline>
                          </fo:block>
                          <fo:block>
                            <fo:inline text-align="left" font-size="7pt">
                              &#x00A0;&#x00A0;&#x00A0;
                            </fo:inline>
                            <fo:inline text-align="left" font-size="7pt">
                              Nivel:
                            </fo:inline>
                            <fo:inline text-align="left" font-size="7pt" font-weight="bold">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/nivel_evaluado"/>
                            </fo:inline>
                            <fo:inline text-align="left" font-size="7pt">
                              Grado:
                            </fo:inline>
                            <fo:inline text-align="left" font-size="7pt" font-weight="bold">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/grado_evaluado"/>
                            </fo:inline>
                            <fo:inline text-align="left" font-size="7pt">
                              Agrupamiento:
                            </fo:inline>
                            <fo:inline text-align="left" font-size="7pt" font-weight="bold">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/agrupamiento_evaluado"/>
                            </fo:inline>
                          </fo:block>
                          <fo:block>
                            <fo:inline text-align="left" font-size="7pt">
                              Nivel Educativo:
                            </fo:inline>
                            <fo:inline text-align="left" font-size="7pt" font-weight="bold">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/nivel_educativo_evaluado"/>
                            </fo:inline>
                          </fo:block>
                        </fo:block>
                      </fo:table-cell>
                    </fo:table-row>
                  </fo:table-body>
                </fo:table>
                <!-- fin tabla agente evaluador y evaluado-->
                <fo:leader />
                <!-- tabla preguntas -->
                <fo:table border-collapse="collapse" table-layout="fixed">
                  <fo:table-column column-width="8cm" column-number="1"/>
                  <fo:table-column column-width="8cm" column-number="2"/>
                  <fo:table-column column-width="0.5cm" column-number="3"/>
                  <fo:table-body>
                    <fo:table-row>
                      <fo:table-cell border-width="0.5pt" border-style="solid" text-align="center" padding="5pt">
                        <fo:block font-size="7pt" font-weight="bold">
                          Factor
                        </fo:block>
                      </fo:table-cell>
                      <fo:table-cell border-width="0.5pt" border-style="solid" text-align="center" padding="5pt">
                        <fo:block font-size="7pt" font-weight="bold">
                          Cualidad
                        </fo:block>
                      </fo:table-cell>
                      <fo:table-cell border-width="0.5pt" border-style="solid" text-align="center" padding="2pt">
                        <fo:block font-size="6pt">
                          Pun
                        </fo:block>
                        <fo:block font-size="6pt">
                          tos
                        </fo:block>
                      </fo:table-cell>
                    </fo:table-row>
                    <xsl:choose>
                      <xsl:when test="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_1 != ''">
                        <fo:table-row>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="left" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_1"/>
                            </fo:block>
                          </fo:table-cell>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="left" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/respuesta_1"/>
                            </fo:block>
                          </fo:table-cell>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="center" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/puntaje_1"/>
                            </fo:block>
                          </fo:table-cell>
                        </fo:table-row>
                      </xsl:when>
                    </xsl:choose>
                    <xsl:choose>
                      <xsl:when test="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_2 != ''">
                        <fo:table-row>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="left" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_2"/>
                            </fo:block>
                          </fo:table-cell>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="left" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/respuesta_2"/>
                            </fo:block>
                          </fo:table-cell>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="center" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/puntaje_2"/>
                            </fo:block>
                          </fo:table-cell>
                        </fo:table-row>
                      </xsl:when>
                    </xsl:choose>
                    <xsl:choose>
                      <xsl:when test="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_3 != ''">
                        <fo:table-row>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="left" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_3"/>
                            </fo:block>
                          </fo:table-cell>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="left" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/respuesta_3"/>
                            </fo:block>
                          </fo:table-cell>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="center" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/puntaje_3"/>
                            </fo:block>
                          </fo:table-cell>
                        </fo:table-row>
                      </xsl:when>
                    </xsl:choose>
                    <xsl:choose>
                      <xsl:when test="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_4 != ''">
                        <fo:table-row>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="left" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_4"/>
                            </fo:block>
                          </fo:table-cell>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="left" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/respuesta_4"/>
                            </fo:block>
                          </fo:table-cell>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="center" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/puntaje_4"/>
                            </fo:block>
                          </fo:table-cell>
                        </fo:table-row>
                      </xsl:when>
                    </xsl:choose>
                    <xsl:choose>
                      <xsl:when test="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_5 != ''">
                        <fo:table-row>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="left" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_5"/>
                            </fo:block>
                          </fo:table-cell>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="left" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/respuesta_5"/>
                            </fo:block>
                          </fo:table-cell>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="center" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/puntaje_5"/>
                            </fo:block>
                          </fo:table-cell>
                        </fo:table-row>
                      </xsl:when>
                    </xsl:choose>
                    <xsl:choose>
                      <xsl:when test="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_6 != ''">
                        <fo:table-row>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="left" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_6"/>
                            </fo:block>
                          </fo:table-cell>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="left" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/respuesta_6"/>
                            </fo:block>
                          </fo:table-cell>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="center" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/puntaje_6"/>
                            </fo:block>
                          </fo:table-cell>
                        </fo:table-row>
                      </xsl:when>
                    </xsl:choose>
                    <xsl:choose>
                      <xsl:when test="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_7 != ''">
                        <fo:table-row>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="left" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_7"/>
                            </fo:block>
                          </fo:table-cell>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="left" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/respuesta_7"/>
                            </fo:block>
                          </fo:table-cell>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="center" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/puntaje_7"/>
                            </fo:block>
                          </fo:table-cell>
                        </fo:table-row>
                      </xsl:when>
                    </xsl:choose>
                    <xsl:choose>
                      <xsl:when test="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_8 != ''">
                        <fo:table-row>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="left" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_8"/>
                            </fo:block>
                          </fo:table-cell>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="left" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/respuesta_8"/>
                            </fo:block>
                          </fo:table-cell>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="center" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/puntaje_8"/>
                            </fo:block>
                          </fo:table-cell>
                        </fo:table-row>
                      </xsl:when>
                    </xsl:choose>
                    <xsl:choose>
                      <xsl:when test="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_9 != ''">
                        <fo:table-row>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="left" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_9"/>
                            </fo:block>
                          </fo:table-cell>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="left" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/respuesta_9"/>
                            </fo:block>
                          </fo:table-cell>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="center" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/puntaje_9"/>
                            </fo:block>
                          </fo:table-cell>
                        </fo:table-row>
                      </xsl:when>
                    </xsl:choose>
                    <xsl:choose>
                      <xsl:when test="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_10 != ''">
                        <fo:table-row>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="left" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_10"/>
                            </fo:block>
                          </fo:table-cell>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="left" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/respuesta_10"/>
                            </fo:block>
                          </fo:table-cell>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="center" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/puntaje_10"/>
                            </fo:block>
                          </fo:table-cell>
                        </fo:table-row>
                      </xsl:when>
                    </xsl:choose>
                    <xsl:choose>
                      <xsl:when test="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_11 != ''">
                        <fo:table-row>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="left" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_11"/>
                            </fo:block>
                          </fo:table-cell>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="left" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/respuesta_11"/>
                            </fo:block>
                          </fo:table-cell>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="center" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/puntaje_11"/>
                            </fo:block>
                          </fo:table-cell>
                        </fo:table-row>
                      </xsl:when>
                    </xsl:choose>
                    <xsl:choose>
                      <xsl:when test="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_12 != ''">
                        <fo:table-row>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="left" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_12"/>
                            </fo:block>
                          </fo:table-cell>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="left" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/respuesta_12"/>
                            </fo:block>
                          </fo:table-cell>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="center" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/puntaje_12"/>
                            </fo:block>
                          </fo:table-cell>
                        </fo:table-row>
                      </xsl:when>
                    </xsl:choose>
                    <xsl:choose>
                      <xsl:when test="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_13 != ''">
                        <fo:table-row>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="left" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_13"/>
                            </fo:block>
                          </fo:table-cell>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="left" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/respuesta_13"/>
                            </fo:block>
                          </fo:table-cell>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="center" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/puntaje_13"/>
                            </fo:block>
                          </fo:table-cell>
                        </fo:table-row>
                      </xsl:when>
                    </xsl:choose>
                    <xsl:choose>
                      <xsl:when test="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_14 != ''">
                        <fo:table-row>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="left" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_14"/>
                            </fo:block>
                          </fo:table-cell>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="left" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/respuesta_14"/>
                            </fo:block>
                          </fo:table-cell>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="center" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/puntaje_14"/>
                            </fo:block>
                          </fo:table-cell>
                        </fo:table-row>
                      </xsl:when>
                    </xsl:choose>
                    <xsl:choose>
                      <xsl:when test="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_15 != ''">
                        <fo:table-row>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="left" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_15"/>
                            </fo:block>
                          </fo:table-cell>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="left" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/respuesta_15"/>
                            </fo:block>
                          </fo:table-cell>
                          <fo:table-cell border-width="0.5pt" border-style="solid" text-align="center" padding="5pt">
                            <fo:block font-size="6pt">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/puntaje_15"/>
                            </fo:block>
                          </fo:table-cell>
                        </fo:table-row>
                      </xsl:when>
                    </xsl:choose>
                    <fo:table-row>
                      <fo:table-cell border-width="0.5pt" border-style="solid" text-align="center" padding="3pt" number-columns-spanned="3">
                        <fo:block font-size="10pt" font-weight="bold">
                          RESULTADO DE LA EVALUACION:
                        </fo:block>
                      </fo:table-cell>
                    </fo:table-row>
                    <fo:table-row>
                      <fo:table-cell border-width="0.5pt" border-style="solid" text-align="center" padding="3pt">
                        <fo:block font-size="9pt">
                          <fo:inline>A) Puntaje Final Obtenido:</fo:inline>
                          <fo:inline font-weight="bold">
                            <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/puntaje"/>
                          </fo:inline>
                        </fo:block>
                      </fo:table-cell>
                      <fo:table-cell border-width="0.5pt" border-style="solid" text-align="center" padding="3pt" number-columns-spanned="2">
                        <fo:block font-size="9pt">
                          <fo:inline font-size="9pt">
                            B) Calificacion Final:
                          </fo:inline>
                          <fo:inline font-weight="bold">
                            <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/calificacion"/>
                          </fo:inline>
                        </fo:block>
                      </fo:table-cell>
                      <fo:table-cell>
                      </fo:table-cell>
                    </fo:table-row>
                  </fo:table-body>
                </fo:table>
                <!--pagina 2-->
                <fo:table break-after="page"></fo:table>
                <!--tabla agente resultado evaluacion-->
                <fo:table>
                  <fo:table-column column-width="8.25cm" column-number="1"/>
                  <fo:table-column column-width="8.25cm" column-number="2"/>
                  <fo:table-body>
                    <fo:table-row >
                      <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt" number-columns-spanned="2">
                        <fo:block  text-align="left" font-size="7pt" font-weight="bold"  >
                          RESULTADO DE LA EVALUACION
                        </fo:block>
                      </fo:table-cell>
                    </fo:table-row>
                    <fo:table-row>
                      <!--  puntaje -->
                      <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt" text-align="left">
                        <fo:block>
                          <fo:block >
                            <fo:inline text-align="left" font-size="9pt">
                              A) Puntaje Final obtenido:
                            </fo:inline>
                            <fo:inline text-align="left" font-size="9pt" font-weight="bold">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/puntaje"/>
                            </fo:inline>
                          </fo:block>
                          <fo:block text-align="center">
                            <fo:inline>
                              <fo:table>
                                <fo:table-column column-width="3.25cm" column-number="1"/>
                                <fo:table-column column-width="3.25cm" column-number="2"/>
                                <fo:table-body>
                                  <fo:table-row >
                                    <fo:table-cell padding="2pt">
                                      <fo:block>
                                        <!--tabla agente resultado evaluacion 1-->
                                        <fo:table>
                                          <fo:table-column column-width="1.25cm" column-number="1"/>
                                          <fo:table-column column-width="1.25cm" column-number="2"/>
                                          <fo:table-body>
                                            <fo:table-row >
                                              <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt">
                                                <fo:block  text-align="left" font-size="7pt" font-weight="bold"  >
                                                  Factor
                                                </fo:block>
                                              </fo:table-cell>
                                              <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt" >
                                                <fo:block  text-align="left" font-size="7pt" font-weight="bold"  >
                                                  Valor
                                                </fo:block>
                                              </fo:table-cell>
                                            </fo:table-row>
                                            <xsl:choose>
                                              <xsl:when test="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_1 != ''">
                                                <fo:table-row >
                                                  <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt">
                                                    <fo:block  text-align="left" font-size="7pt" font-weight="bold"  >
                                                      01
                                                    </fo:block>
                                                  </fo:table-cell>
                                                  <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt" >
                                                    <fo:block  text-align="left" font-size="7pt" font-weight="bold"  >
                                                      <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/puntaje_1"/>
                                                    </fo:block>
                                                  </fo:table-cell>
                                                </fo:table-row>
                                              </xsl:when>
                                            </xsl:choose>
                                            <xsl:choose>
                                              <xsl:when test="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_2 != ''">
                                                <fo:table-row >
                                                  <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt">
                                                    <fo:block  text-align="left" font-size="7pt" font-weight="bold"  >
                                                      02
                                                    </fo:block>
                                                  </fo:table-cell>
                                                  <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt" >
                                                    <fo:block  text-align="left" font-size="7pt" font-weight="bold"  >
                                                      <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/puntaje_2"/>
                                                    </fo:block>
                                                  </fo:table-cell>
                                                </fo:table-row>
                                              </xsl:when>
                                            </xsl:choose>
                                            <xsl:choose>
                                              <xsl:when test="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_3 != ''">
                                                <fo:table-row >
                                                  <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt">
                                                    <fo:block  text-align="left" font-size="7pt" font-weight="bold"  >
                                                      03
                                                    </fo:block>
                                                  </fo:table-cell>
                                                  <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt" >
                                                    <fo:block  text-align="left" font-size="7pt" font-weight="bold"  >
                                                      <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/puntaje_3"/>
                                                    </fo:block>
                                                  </fo:table-cell>
                                                </fo:table-row>
                                              </xsl:when>
                                            </xsl:choose>
                                            <xsl:choose>
                                              <xsl:when test="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_4 != ''">
                                                <fo:table-row >
                                                  <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt">
                                                    <fo:block  text-align="left" font-size="7pt" font-weight="bold"  >
                                                      04
                                                    </fo:block>
                                                  </fo:table-cell>
                                                  <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt" >
                                                    <fo:block  text-align="left" font-size="7pt" font-weight="bold"  >
                                                      <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/puntaje_4"/>
                                                    </fo:block>
                                                  </fo:table-cell>
                                                </fo:table-row>
                                              </xsl:when>
                                            </xsl:choose>
                                            <xsl:choose>
                                              <xsl:when test="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_5 != ''">
                                                <fo:table-row >
                                                  <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt">
                                                    <fo:block  text-align="left" font-size="7pt" font-weight="bold"  >
                                                      05
                                                    </fo:block>
                                                  </fo:table-cell>
                                                  <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt" >
                                                    <fo:block  text-align="left" font-size="7pt" font-weight="bold"  >
                                                      <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/puntaje_5"/>
                                                    </fo:block>
                                                  </fo:table-cell>
                                                </fo:table-row>
                                              </xsl:when>
                                            </xsl:choose>
                                            <xsl:choose>
                                              <xsl:when test="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_6 != ''">
                                                <fo:table-row >
                                                  <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt">
                                                    <fo:block  text-align="left" font-size="7pt" font-weight="bold"  >
                                                      06
                                                    </fo:block>
                                                  </fo:table-cell>
                                                  <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt" >
                                                    <fo:block  text-align="left" font-size="7pt" font-weight="bold"  >
                                                      <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/puntaje_6"/>
                                                    </fo:block>
                                                  </fo:table-cell>
                                                </fo:table-row>
                                              </xsl:when>
                                            </xsl:choose>
                                            <xsl:choose>
                                              <xsl:when test="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_7 != ''">
                                                <fo:table-row >
                                                  <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt">
                                                    <fo:block  text-align="left" font-size="7pt" font-weight="bold"  >
                                                      07
                                                    </fo:block>
                                                  </fo:table-cell>
                                                  <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt" >
                                                    <fo:block  text-align="left" font-size="7pt" font-weight="bold"  >
                                                      <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/puntaje_7"/>
                                                    </fo:block>
                                                  </fo:table-cell>
                                                </fo:table-row>
                                              </xsl:when>
                                            </xsl:choose>
                                          </fo:table-body>
                                        </fo:table>
                                        <!--fin tabla agente resultado evaluacion-->
                                      </fo:block>
                                    </fo:table-cell>
                                    <xsl:choose>
                                      <xsl:when test="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_8 != ''">
                                        <fo:table-cell padding="2pt">
                                          <!--tabla agente resultado evaluacion 2-->
                                          <fo:table>
                                            <fo:table-column column-width="1.25cm" column-number="1"/>
                                            <fo:table-column column-width="1.25cm" column-number="2"/>
                                            <fo:table-body>
                                              <fo:table-row >
                                                <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt">
                                                  <fo:block  text-align="left" font-size="7pt" font-weight="bold"  >
                                                    Factor
                                                  </fo:block>
                                                </fo:table-cell>
                                                <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt" >
                                                  <fo:block  text-align="left" font-size="7pt" font-weight="bold"  >
                                                    Valor
                                                  </fo:block>
                                                </fo:table-cell>
                                              </fo:table-row>
                                              <xsl:choose>
                                                <xsl:when test="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_8 != ''">
                                                  <fo:table-row >
                                                    <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt">
                                                      <fo:block  text-align="left" font-size="7pt" font-weight="bold"  >
                                                        08
                                                      </fo:block>
                                                    </fo:table-cell>
                                                    <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt" >
                                                      <fo:block  text-align="left" font-size="7pt" font-weight="bold"  >
                                                        <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/puntaje_8"/>
                                                      </fo:block>
                                                    </fo:table-cell>
                                                  </fo:table-row>
                                                </xsl:when>
                                              </xsl:choose>
                                              <xsl:choose>
                                                <xsl:when test="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_9 != ''">

                                                  <fo:table-row >
                                                    <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt">
                                                      <fo:block  text-align="left" font-size="7pt" font-weight="bold"  >
                                                        09
                                                      </fo:block>
                                                    </fo:table-cell>
                                                    <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt" >
                                                      <fo:block  text-align="left" font-size="7pt" font-weight="bold"  >
                                                        <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/puntaje_9"/>
                                                      </fo:block>
                                                    </fo:table-cell>
                                                  </fo:table-row>
                                                </xsl:when>
                                              </xsl:choose>
                                              <xsl:choose>
                                                <xsl:when test="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_10 != ''">
                                                  <fo:table-row >
                                                    <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt">
                                                      <fo:block  text-align="left" font-size="7pt" font-weight="bold"  >
                                                        10
                                                      </fo:block>
                                                    </fo:table-cell>
                                                    <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt" >
                                                      <fo:block  text-align="left" font-size="7pt" font-weight="bold"  >
                                                        <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/puntaje_10"/>
                                                      </fo:block>
                                                    </fo:table-cell>
                                                  </fo:table-row>
                                                </xsl:when>
                                              </xsl:choose>
                                              <xsl:choose>
                                                <xsl:when test="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_11 != ''">
                                                  <fo:table-row >
                                                    <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt">
                                                      <fo:block  text-align="left" font-size="7pt" font-weight="bold"  >
                                                        11
                                                      </fo:block>
                                                    </fo:table-cell>
                                                    <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt" >
                                                      <fo:block  text-align="left" font-size="7pt" font-weight="bold"  >
                                                        <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/puntaje_11"/>
                                                      </fo:block>
                                                    </fo:table-cell>
                                                  </fo:table-row>
                                                </xsl:when>
                                              </xsl:choose>
                                              <xsl:choose>
                                                <xsl:when test="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_12 != ''">
                                                  <fo:table-row >
                                                    <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt">
                                                      <fo:block  text-align="left" font-size="7pt" font-weight="bold"  >
                                                        12
                                                      </fo:block>
                                                    </fo:table-cell>
                                                    <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt" >
                                                      <fo:block  text-align="left" font-size="7pt" font-weight="bold"  >
                                                        <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/puntaje_12"/>
                                                      </fo:block>
                                                    </fo:table-cell>
                                                  </fo:table-row>
                                                </xsl:when>
                                              </xsl:choose>
                                              <xsl:choose>
                                                <xsl:when test="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_13 != ''">
                                                  <fo:table-row >
                                                    <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt">
                                                      <fo:block  text-align="left" font-size="7pt" font-weight="bold"  >
                                                        13
                                                      </fo:block>
                                                    </fo:table-cell>
                                                    <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt" >
                                                      <fo:block  text-align="left" font-size="7pt" font-weight="bold"  >
                                                        <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/puntaje_13"/>
                                                      </fo:block>
                                                    </fo:table-cell>
                                                  </fo:table-row>
                                                </xsl:when>
                                              </xsl:choose>
                                              <xsl:choose>
                                                <xsl:when test="/PdfPrinter/EvaluacionDesempenioPdfTO/pregunta_14 != ''">
                                                  <fo:table-row >
                                                    <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt">
                                                      <fo:block  text-align="left" font-size="7pt" font-weight="bold"  >
                                                        14
                                                      </fo:block>
                                                    </fo:table-cell>
                                                    <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt" >
                                                      <fo:block  text-align="left" font-size="7pt" font-weight="bold"  >
                                                        <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/puntaje_14"/>
                                                      </fo:block>
                                                    </fo:table-cell>
                                                  </fo:table-row>
                                                </xsl:when>
                                              </xsl:choose>
                                            </fo:table-body>
                                          </fo:table>
                                          <!--fin tabla agente resultado evaluacion 2-->
                                        </fo:table-cell>
                                      </xsl:when>
                                    </xsl:choose>
                                  </fo:table-row>
                                </fo:table-body>
                              </fo:table>
                            </fo:inline>
                          </fo:block>
                        </fo:block>
                      </fo:table-cell>
                      <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt" text-align="left">
                        <fo:block>
                          <fo:block>
                            <fo:inline text-align="left" font-size="9pt">
                              B) Calificacion Final:
                            </fo:inline>
                            <fo:inline font-weight="bold">
                              <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/calificacion"/>
                            </fo:inline>
                          </fo:block>
                          <fo:block>
                            <fo:table>
                              <fo:table-column column-width="7.25cm" column-number="1"/>
                              <fo:table-body>
                                <fo:table-row >
                                  <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt" >
                                    <fo:block  text-align="left" font-size="7pt" >
                                      (1) En caso de que el agente haya calificado "Regular o "Deficiente" se deberá adjuntar el Formulario "B" con el programa de Recuperación.&#x0A;
                                      <xsl:value-of select="'&#x2028;'"/><xsl:value-of select="'&#x2028;'"/>
                                      (2) Los agentes que hayan tenido sanciones disciplinaias en el período evaluado no pueden calificar "Destacado" o "Muy Destacado"
                                    </fo:block>
                                  </fo:table-cell>
                                </fo:table-row>
                              </fo:table-body>
                            </fo:table>
                          </fo:block>
                        </fo:block>

                      </fo:table-cell>
                      <!--  fin resultado evaluacion -->
                    </fo:table-row>
                  </fo:table-body>
                </fo:table>
              </fo:block>
            </fo:block>
          </fo:block>
          <fo:block id="last-page"/>
        </fo:flow>
      </fo:page-sequence>
    </fo:root>
  </xsl:template>
</xsl:stylesheet>
