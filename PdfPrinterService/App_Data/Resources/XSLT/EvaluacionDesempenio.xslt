<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt"
    xmlns:utilityExtension="pdfprinter:extensions:utility"
    exclude-result-prefixes="msxsl utilityExtension"
>
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
            <fo:block padding-top="2pt">
              <fo:block text-align="left" font-size="16pt">
                <fo:inline font-weight="bold">
                  <xsl:value-of select="/PdfPrinter/culture/label[@id='Message']/@text"/>
                </fo:inline>
              </fo:block>
              <fo:block text-align="left" padding-top="2pt" font-size="16pt">
                <xsl:choose>
                  <xsl:when test="/PdfPrinter/EvaluacionDesempenioDTO/Description != ''">
                    <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioDTO/Description"/>
                  </xsl:when>
                  <xsl:otherwise>
                    <xsl:value-of select="/PdfPrinter/culture/label[@id='EmptyMessage']/@text"/>
                  </xsl:otherwise>
                </xsl:choose>
              </fo:block>
            </fo:block>
          </fo:block>


          <fo:block text-align="center" padding-top="1cm">
            <fo:table border-collapse="collapse" table-layout="fixed">
              <fo:table-column column-width="4cm" column-number="1"/>
              <fo:table-column column-width="4cm" column-number="2"/>
              <fo:table-column column-width="4cm" column-number="3"/>
              <fo:table-column column-width="5cm" column-number="4"/>             
              <fo:table-header>
                <fo:table-row height="1cm" display-align="center">
                  <fo:table-cell text-align="center" border-width="0.5pt" border-style="solid" padding="0.5pt">
                    <fo:block text-align="center" font-weight="bold">
					  <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioDTO/Date_Header_1"/>
                    </fo:block>
                  </fo:table-cell>
                  <fo:table-cell text-align="center" border-width="0.5pt" border-style="solid" padding="0.5pt">
                    <fo:block text-align="center" font-weight="bold">
                      <xsl:value-of select="/PdfPrinter/culture/label[@id='LongWord_Header_2']/@text"/>
                    </fo:block>
                  </fo:table-cell>
                  <fo:table-cell text-align="center" border-width="0.5pt" border-style="solid" padding="0.5pt">
                    <fo:block text-align="center" font-weight="bold">
                      <xsl:value-of select="/PdfPrinter/culture/label[@id='Decimal_Header_3']/@text"/>
                    </fo:block>
                  </fo:table-cell>
                  <fo:table-cell text-align="center" border-width="0.5pt" border-style="solid" padding="0.5pt">
                    <fo:block text-align="center" font-weight="bold">
                      <xsl:value-of select="/PdfPrinter/culture/label[@id='Integer_Header_4']/@text"/>
                    </fo:block>
                  </fo:table-cell>                  
                </fo:table-row>
              </fo:table-header>
              <fo:table-body>

                <fo:table-row>
                  <fo:table-cell border-width="0.5pt" border-style="solid" text-align="center" padding="2pt">
                    <fo:block>
                      <xsl:value-of select="utilityExtension:FormatDateTime(/PdfPrinter/culture/label[@id='Date_Field_1']/@text)"/>
                    </fo:block>
                  </fo:table-cell>
                  <fo:table-cell border-width="0.5pt" border-style="solid" text-align="center" padding="2pt">
                    <fo:block>
                      <xsl:value-of select="utilityExtension:BreakWords(/PdfPrinter/culture/label[@id='LongWord_Field_2']/@text, 12)"/>
                    </fo:block>
                  </fo:table-cell>                  
                  <fo:table-cell border-width="0.5pt" border-style="solid" text-align="right" padding="2pt">
                    <fo:block>
                      <xsl:value-of select="utilityExtension:FormatDecimal(/PdfPrinter/culture/label[@id='Decimal_Field_3']/@text)"/>
                    </fo:block>
                  </fo:table-cell>
                  <fo:table-cell border-width="0.5pt" border-style="solid" text-align="right" padding="2pt">
                    <fo:block>
                      <xsl:value-of select="utilityExtension:FormatInteger(/PdfPrinter/culture/label[@id='Integer_Field_4']/@text)"/>
                    </fo:block>
                  </fo:table-cell>                 
                </fo:table-row>

                <fo:table-row>
                  <fo:table-cell>
                    <fo:block/>
                  </fo:table-cell>                
                  <fo:table-cell border-width="0.5pt" border-style="solid" number-columns-spanned="2" padding="2pt">
                    <fo:block text-align="left" font-weight="normal">
                      <xsl:value-of select="/PdfPrinter/culture/label[@id='Total']/@text"/>
                    </fo:block>
                  </fo:table-cell>
                  <fo:table-cell background-color="rgb(255,255,179)" border-width="0.5pt" border-style="solid" text-align="right" font-weight="bold" number-columns-spanned="2" padding="2pt">
                    <fo:block>
                      <xsl:value-of select="utilityExtension:FormatDecimal(/PdfPrinter/culture/label[@id='Decimal_Field_3']/@text)"/>
                    </fo:block>
                  </fo:table-cell>
                </fo:table-row>
              </fo:table-body>
            </fo:table>
          </fo:block>


          <fo:block id="last-page"/>
        </fo:flow>
      </fo:page-sequence>
    </fo:root>

  </xsl:template>
</xsl:stylesheet>
