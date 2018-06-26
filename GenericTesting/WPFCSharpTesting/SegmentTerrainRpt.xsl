<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  
    <xsl:output method="html" indent="yes"/>
    <xsl:strip-space elements="*"/>      

    <xsl:variable name="TerrainAlert" select="'8000'"/>
    
    <xsl:template match="JP_Reply">
      <html lang="en">
        <head>
          <meta charset="utf-8" />
          <title>Segment Terrain Profile Report</title>
          <style>
            h1 {margin-left: 10px;font-style:italic; }
            table {clear: both;width: 100%;margin-top: 50px}
            th { text-align: left;}
            td, th { padding: 5px;}
            .xtninfo { float: left;margin: 2px 10px 2px 10px; }
            .xtninforow { clear: both; }
            .fields { margin-right: 5px; font-weight:bold;}
            .warn { background-color: #FFEA77;}
          </style>
        </head>
        <body>
          <header>
            <h1>Segment Terrain Profile Report</h1>
          </header>
          <section>
            <xsl:apply-templates select="XTNInfo"/>
          </section>
          <section>
            <table>
              <colgroup>
                <col class="distance"/>
                <col class="height"/>
              </colgroup>
              <thead>
                <tr>
                  <th>Distance (nm)</th>
                  <th>Height (ft)</th>            
                </tr>
              </thead>
              <tbody>
                <xsl:apply-templates select="XTNInfo/XTNSEG_Data"/>          
              </tbody>      
            </table>    
          </section>
        </body>
      </html>
    </xsl:template>

    <xsl:template match="XTNInfo">
      <div class="xtninforow">
        <div class="xtninfo"><span class="fields">FROM:</span><xsl:value-of select="normalize-space(@startPoint)"/></div>
        <div class="xtninfo"><span class="fields">TO:</span><xsl:value-of select="normalize-space(@endPoint)"/></div>
      </div>
      <div class="xtninforow">
        <div class="xtninfo"><span class="fields">COURSE:</span><xsl:value-of select="format-number(normalize-space(@segmentTrueCourse), '000')"/> DEG</div>
        <div class="xtninfo"><span class="fields">DISTANCE:</span><xsl:value-of select="format-number(normalize-space(@segmentDistance), '###,###.000')"/> NM</div>
        <div class="xtninfo"><span class="fields">MAX TERRAIN HEIGHT:</span><xsl:value-of select="format-number(normalize-space(@segmentMaxTerrainHeight), '###,###')"/> FT</div>
      </div>
    </xsl:template>

    <xsl:template match="XTNSEG_Data">
      <tr>
        <xsl:if test="maxTerrainHeight > $TerrainAlert">
          <xsl:attribute name="class">warn</xsl:attribute>
        </xsl:if>
        
        <td>
          <xsl:value-of select="format-number(normalize-space(cumulativeDistance), '###,##0.00')"/>
        </td>
        <td>
          <xsl:value-of select="format-number(normalize-space(maxTerrainHeight), '###,###')"/>
        </td>
      </tr>
    </xsl:template>

</xsl:stylesheet>
