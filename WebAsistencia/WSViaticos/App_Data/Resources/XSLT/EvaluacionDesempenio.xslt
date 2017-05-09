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
                  <xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/Agente"/>
                </fo:inline>
              </fo:block>
              <fo:block text-align="left" padding-top="2pt" font-size="16pt">
				<xsl:value-of select="/PdfPrinter/EvaluacionDesempenioPdfTO/Nivel"/>
              </fo:block>
            </fo:block>
          </fo:block>
          <fo:block id="last-page"/>
        </fo:flow>
      </fo:page-sequence>
    </fo:root>

  </xsl:template>
</xsl:stylesheet>
