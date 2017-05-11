<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt"
    xmlns:utilityExtension="pdfprinter:extensions:utility"
    exclude-result-prefixes="msxsl utilityExtension">
  <xsl:output method="xml" indent="yes" omit-xml-declaration="yes" encoding="utf-8"/>
  <xsl:template match="/">
    <xsl:variable name="logo" select="utilityExtension:MapPath('~/App_Data/Resources/IMAGES/logo.jpg')"/>
    <fo:root xmlns:fo="http://www.w3.org/1999/XSL/Format">
      <fo:layout-master-set>
        <fo:simple-page-master master-name="simple"
                      page-height="29.7cm"
                      page-width="21cm"
                      margin-top="0.5cm"
                      margin-bottom="0.5cm"
                      margin-left="2cm"
                      margin-right="2cm">
          <fo:region-body margin-top="1cm" margin-bottom="4cm"/>
          <fo:region-before extent="1cm"/>
          <!-- Header -->
          <fo:region-after extent="3cm"/>
          <!-- Footer -->
        </fo:simple-page-master>
      </fo:layout-master-set>
      <fo:page-sequence master-reference="simple">
        <fo:static-content flow-name="xsl-region-after" >
          <fo:block border-bottom-width="2pt" border-bottom-style="solid" border-bottom-color="rgb(0, 0, 0)"></fo:block>
          <fo:block padding-top="0.2cm" text-align="center">
            <fo:block font-size="9pt">
              <xsl:value-of select="/PdfPrinter/culture/label[@id='Footer']/@text"/>
            </fo:block>
          </fo:block>
          <fo:block text-align="right" font-size="8pt" padding-top="0.5cm">
            <xsl:value-of select="/PdfPrinter/culture/label[@id='Page']/@text"/>
            <fo:page-number/>
            <xsl:value-of select="/PdfPrinter/culture/label[@id='Of']/@text"/>
            <fo:page-number-citation ref-id="last-page"/>
          </fo:block>
        </fo:static-content>
        <fo:flow flow-name="xsl-region-body" font-family="Helvetica" font-size="11pt">
          <fo:block>
            <fo:block>
              <fo:external-graphic src="url('{$logo}')" content-width="auto" content-height="auto"/>
            </fo:block>
            <fo:block>
              <fo:block padding-top="2pt">
                <fo:block text-align="center" padding-top="1cm">
                  <!-- tabla cabecera -->
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
                            |||||||||||||
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
                            <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/nivel_descripcion_larga"/>
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
                      <fo:table-cell border-width="0.5pt" border-style="solid"  padding="2pt" >
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
                      <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt">
                        <fo:block text-align="left" font-size="7pt" font-weight="bold">
                          IDENTIFICACION DEL AGENTE
                        </fo:block>
                      </fo:table-cell>
                    </fo:table-row>
                    <fo:table-row>
                      <!--  evaluador -->
                      <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt">
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
                      <fo:table-cell border-width="0.5pt" border-style="solid" padding="2pt">
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
              </fo:block>
            </fo:block>
          </fo:block>
          <fo:block id="last-page"/>
        </fo:flow>
      </fo:page-sequence>
    </fo:root>
  </xsl:template>
</xsl:stylesheet>
