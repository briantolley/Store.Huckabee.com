<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Product.aspx.vb" Inherits="Store.Huckabee.com.Product" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title><% =lstrProductNameToDisplay %></title>
    <link rel="shortcut icon" type="image/png" href="Images/icon.png" />
    <script type="text/javascript" src="jquery-1.11.2.min.js"></script>
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400italic,400,300,600,700,800" rel="stylesheet" type="text/css"/>
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:400italic,400,300,600,700,800" rel="stylesheet" type="text/css"/>
    <style>
        .dropdown {
            height:100%;
            width:87px;
            border-radius: 3px;
            font-family:'Open Sans', Helvetica, sans-serif;
            font-weight:300;
            font-size:100%;
            color: black;
            text-decoration: none;
        }
        .dropdown2 {
            height:100%;
            width:86px;
            border-radius: 3px;
            font-family:'Open Sans', Helvetica, sans-serif;
            font-weight:300;
            font-size:100%;
            color: black;
            text-decoration: none;
        }
        .productimage {
            width:90%;
        }
    </style>
</head>
<body style="padding: 0px; margin: 0px;"  >
    <form id="form1" runat="server">
        <table style="table-layout: fixed;border: 0px; width: 100%; height: 100%; padding: 0px; margin: 0px; border-width: 0px; empty-cells: hide; border-collapse: collapse; border-spacing: 0px;min-width:800px">
            <tr>
                <td>
                    <!-- #include file="Includes/Header.aspx -->
                    <table  border="0" style="border-style: solid; table-layout: fixed; width: 100%; padding: 0px; margin: 0px; border-width: 1px 0px 0px 0px; empty-cells: hide; border-collapse: collapse; border-spacing: 0px; border-top-color: #BFBFBF; border-right-color: inherit; border-bottom-color: inherit; border-left-color: inherit;">
                        <tr style="text-align: center; height: 1px; border: 0px; width: 100%; padding: 0px; margin: 0px; border-width: 0px; background-repeat: repeat;">
                            <td style="width: 8.25%; text-align: center;"></td>
                            <td style="text-align: center;"></td>
                            <td style="width: 8.25%; text-align: center;"></td>
                        </tr>
                        <tr style="background-color: white; text-align: center;border: 0px; width: 100%; padding: 0px; margin: 0px; border-width: 0px;">
                            <td style="width: 8.25%; text-align: center;"></td>
                            <td style="background-color: white; width: 10%; text-align: center;">
                                <table border="0">
                                    <tr>
                                        <td style="width:50%;text-align:left;">
                                            <br /><br /><br /><br />
                                            <label for="label2" style="font-family:'Open Sans', Helvetica, sans-serif;font-weight:600;font-size:100%;color: #044C86;text-decoration: none;"><% = lstrProductNameToDisplay%></label>
                                            <br></br> 
                                            <% If (drpQty.SelectedValue >= llngPriceBreakOnQuantity) And (llngPriceBreakOnQuantity > 0) Then%>
                                                <label for="label2" style="font-family:'Open Sans', Helvetica, sans-serif;font-weight:800;font-size:100%;color: #044C86;text-decoration: none;"><% =FormatCurrency(lstrPriceAfterQuantityMet, 2) %></label>
                                            <% Else%>
                                                <label for="label2" style="font-family:'Open Sans', Helvetica, sans-serif;font-weight:800;font-size:100%;color: #044C86;text-decoration: none;"><% =FormatCurrency(lstrProductItemPrice, 2)%></label>
                                            <% End If%>
                                            <% If (llngPriceBreakOnQuantity > 0) Then%>
                                                </br><label for="label2" style="font-family:'Open Sans', Helvetica, sans-serif;font-weight:600;font-size:66%;color: #FF0000;text-decoration: none;"><i>* volume discount eligible on <% = CStr(llngPriceBreakOnQuantity)%> items or more.</i></label><br />
                                            <% Else%>
                                                <br></br>
                                            <% End If%>
                                            <br></br> 
                                            <label for="label2" style="font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:80%;color: #000000;text-decoration: none;">
                                                <% =lstrProductNarrative %>
                                            </label><br /><br />
                                            <table  border="0" style="border-style: solid; table-layout: fixed; width: 100%; padding: 0px; margin: 0px; border-width: 1px 0px 0px 0px; empty-cells: hide; border-collapse: collapse; border-spacing: 0px; border-top-color: #BFBFBF; border-right-color: inherit; border-bottom-color: inherit; border-left-color: inherit;">
                                                <tr><td></td></tr>
                                            </table><br />
                                            <asp:PlaceHolder ID="plcDimensions" runat="server"></asp:PlaceHolder>
                                            <label for="label2" style="font-family:'Open Sans', Helvetica, sans-serif;font-weight:300;font-size:100%;color: black;text-decoration: none;">Quantity :</label>
                                            <asp:DropDownList ID="drpQty" runat="server" CssClass="dropdown" AutoPostBack="True">
                                                <asp:ListItem>1</asp:ListItem>
<asp:ListItem>2</asp:ListItem>
<asp:ListItem>3</asp:ListItem>
<asp:ListItem>4</asp:ListItem>
<asp:ListItem>5</asp:ListItem>
<asp:ListItem>6</asp:ListItem>
<asp:ListItem>7</asp:ListItem>
<asp:ListItem>8</asp:ListItem>
<asp:ListItem>9</asp:ListItem>
<asp:ListItem>10</asp:ListItem>
<asp:ListItem>11</asp:ListItem>
<asp:ListItem>12</asp:ListItem>
<asp:ListItem>13</asp:ListItem>
<asp:ListItem>14</asp:ListItem>
<asp:ListItem>15</asp:ListItem>
<asp:ListItem>16</asp:ListItem>
<asp:ListItem>17</asp:ListItem>
<asp:ListItem>18</asp:ListItem>
<asp:ListItem>19</asp:ListItem>
<asp:ListItem>20</asp:ListItem>
<asp:ListItem>21</asp:ListItem>
<asp:ListItem>22</asp:ListItem>
<asp:ListItem>23</asp:ListItem>
<asp:ListItem>24</asp:ListItem>
<asp:ListItem>25</asp:ListItem>
<asp:ListItem>26</asp:ListItem>
<asp:ListItem>27</asp:ListItem>
<asp:ListItem>28</asp:ListItem>
<asp:ListItem>29</asp:ListItem>
<asp:ListItem>30</asp:ListItem>
<asp:ListItem>31</asp:ListItem>
<asp:ListItem>32</asp:ListItem>
<asp:ListItem>33</asp:ListItem>
<asp:ListItem>34</asp:ListItem>
<asp:ListItem>35</asp:ListItem>
<asp:ListItem>36</asp:ListItem>
<asp:ListItem>37</asp:ListItem>
<asp:ListItem>38</asp:ListItem>
<asp:ListItem>39</asp:ListItem>
<asp:ListItem>40</asp:ListItem>
<asp:ListItem>41</asp:ListItem>
<asp:ListItem>42</asp:ListItem>
<asp:ListItem>43</asp:ListItem>
<asp:ListItem>44</asp:ListItem>
<asp:ListItem>45</asp:ListItem>
<asp:ListItem>46</asp:ListItem>
<asp:ListItem>47</asp:ListItem>
<asp:ListItem>48</asp:ListItem>
<asp:ListItem>49</asp:ListItem>
<asp:ListItem>50</asp:ListItem>
<asp:ListItem>51</asp:ListItem>
<asp:ListItem>52</asp:ListItem>
<asp:ListItem>53</asp:ListItem>
<asp:ListItem>54</asp:ListItem>
<asp:ListItem>55</asp:ListItem>
<asp:ListItem>56</asp:ListItem>
<asp:ListItem>57</asp:ListItem>
<asp:ListItem>58</asp:ListItem>
<asp:ListItem>59</asp:ListItem>
<asp:ListItem>60</asp:ListItem>
<asp:ListItem>61</asp:ListItem>
<asp:ListItem>62</asp:ListItem>
<asp:ListItem>63</asp:ListItem>
<asp:ListItem>64</asp:ListItem>
<asp:ListItem>65</asp:ListItem>
<asp:ListItem>66</asp:ListItem>
<asp:ListItem>67</asp:ListItem>
<asp:ListItem>68</asp:ListItem>
<asp:ListItem>69</asp:ListItem>
<asp:ListItem>70</asp:ListItem>
<asp:ListItem>71</asp:ListItem>
<asp:ListItem>72</asp:ListItem>
<asp:ListItem>73</asp:ListItem>
<asp:ListItem>74</asp:ListItem>
<asp:ListItem>75</asp:ListItem>
<asp:ListItem>76</asp:ListItem>
<asp:ListItem>77</asp:ListItem>
<asp:ListItem>78</asp:ListItem>
<asp:ListItem>79</asp:ListItem>
<asp:ListItem>80</asp:ListItem>
<asp:ListItem>81</asp:ListItem>
<asp:ListItem>82</asp:ListItem>
<asp:ListItem>83</asp:ListItem>
<asp:ListItem>84</asp:ListItem>
<asp:ListItem>85</asp:ListItem>
<asp:ListItem>86</asp:ListItem>
<asp:ListItem>87</asp:ListItem>
<asp:ListItem>88</asp:ListItem>
<asp:ListItem>89</asp:ListItem>
<asp:ListItem>90</asp:ListItem>
<asp:ListItem>91</asp:ListItem>
<asp:ListItem>92</asp:ListItem>
<asp:ListItem>93</asp:ListItem>
<asp:ListItem>94</asp:ListItem>
<asp:ListItem>95</asp:ListItem>
<asp:ListItem>96</asp:ListItem>
<asp:ListItem>97</asp:ListItem>
<asp:ListItem>98</asp:ListItem>
<asp:ListItem>99</asp:ListItem>
<asp:ListItem>100</asp:ListItem>
<asp:ListItem>101</asp:ListItem>
<asp:ListItem>102</asp:ListItem>
<asp:ListItem>103</asp:ListItem>
<asp:ListItem>104</asp:ListItem>
<asp:ListItem>105</asp:ListItem>
<asp:ListItem>106</asp:ListItem>
<asp:ListItem>107</asp:ListItem>
<asp:ListItem>108</asp:ListItem>
<asp:ListItem>109</asp:ListItem>
<asp:ListItem>110</asp:ListItem>
<asp:ListItem>111</asp:ListItem>
<asp:ListItem>112</asp:ListItem>
<asp:ListItem>113</asp:ListItem>
<asp:ListItem>114</asp:ListItem>
<asp:ListItem>115</asp:ListItem>
<asp:ListItem>116</asp:ListItem>
<asp:ListItem>117</asp:ListItem>
<asp:ListItem>118</asp:ListItem>
<asp:ListItem>119</asp:ListItem>
<asp:ListItem>120</asp:ListItem>
<asp:ListItem>121</asp:ListItem>
<asp:ListItem>122</asp:ListItem>
<asp:ListItem>123</asp:ListItem>
<asp:ListItem>124</asp:ListItem>
<asp:ListItem>125</asp:ListItem>
<asp:ListItem>126</asp:ListItem>
<asp:ListItem>127</asp:ListItem>
<asp:ListItem>128</asp:ListItem>
<asp:ListItem>129</asp:ListItem>
<asp:ListItem>130</asp:ListItem>
<asp:ListItem>131</asp:ListItem>
<asp:ListItem>132</asp:ListItem>
<asp:ListItem>133</asp:ListItem>
<asp:ListItem>134</asp:ListItem>
<asp:ListItem>135</asp:ListItem>
<asp:ListItem>136</asp:ListItem>
<asp:ListItem>137</asp:ListItem>
<asp:ListItem>138</asp:ListItem>
<asp:ListItem>139</asp:ListItem>
<asp:ListItem>140</asp:ListItem>
<asp:ListItem>141</asp:ListItem>
<asp:ListItem>142</asp:ListItem>
<asp:ListItem>143</asp:ListItem>
<asp:ListItem>144</asp:ListItem>
<asp:ListItem>145</asp:ListItem>
<asp:ListItem>146</asp:ListItem>
<asp:ListItem>147</asp:ListItem>
<asp:ListItem>148</asp:ListItem>
<asp:ListItem>149</asp:ListItem>
<asp:ListItem>150</asp:ListItem>
<asp:ListItem>151</asp:ListItem>
<asp:ListItem>152</asp:ListItem>
<asp:ListItem>153</asp:ListItem>
<asp:ListItem>154</asp:ListItem>
<asp:ListItem>155</asp:ListItem>
<asp:ListItem>156</asp:ListItem>
<asp:ListItem>157</asp:ListItem>
<asp:ListItem>158</asp:ListItem>
<asp:ListItem>159</asp:ListItem>
<asp:ListItem>160</asp:ListItem>
<asp:ListItem>161</asp:ListItem>
<asp:ListItem>162</asp:ListItem>
<asp:ListItem>163</asp:ListItem>
<asp:ListItem>164</asp:ListItem>
<asp:ListItem>165</asp:ListItem>
<asp:ListItem>166</asp:ListItem>
<asp:ListItem>167</asp:ListItem>
<asp:ListItem>168</asp:ListItem>
<asp:ListItem>169</asp:ListItem>
<asp:ListItem>170</asp:ListItem>
<asp:ListItem>171</asp:ListItem>
<asp:ListItem>172</asp:ListItem>
<asp:ListItem>173</asp:ListItem>
<asp:ListItem>174</asp:ListItem>
<asp:ListItem>175</asp:ListItem>
<asp:ListItem>176</asp:ListItem>
<asp:ListItem>177</asp:ListItem>
<asp:ListItem>178</asp:ListItem>
<asp:ListItem>179</asp:ListItem>
<asp:ListItem>180</asp:ListItem>
<asp:ListItem>181</asp:ListItem>
<asp:ListItem>182</asp:ListItem>
<asp:ListItem>183</asp:ListItem>
<asp:ListItem>184</asp:ListItem>
<asp:ListItem>185</asp:ListItem>
<asp:ListItem>186</asp:ListItem>
<asp:ListItem>187</asp:ListItem>
<asp:ListItem>188</asp:ListItem>
<asp:ListItem>189</asp:ListItem>
<asp:ListItem>190</asp:ListItem>
<asp:ListItem>191</asp:ListItem>
<asp:ListItem>192</asp:ListItem>
<asp:ListItem>193</asp:ListItem>
<asp:ListItem>194</asp:ListItem>
<asp:ListItem>195</asp:ListItem>
<asp:ListItem>196</asp:ListItem>
<asp:ListItem>197</asp:ListItem>
<asp:ListItem>198</asp:ListItem>
<asp:ListItem>199</asp:ListItem>
<asp:ListItem>200</asp:ListItem>
<asp:ListItem>201</asp:ListItem>
<asp:ListItem>202</asp:ListItem>
<asp:ListItem>203</asp:ListItem>
<asp:ListItem>204</asp:ListItem>
<asp:ListItem>205</asp:ListItem>
<asp:ListItem>206</asp:ListItem>
<asp:ListItem>207</asp:ListItem>
<asp:ListItem>208</asp:ListItem>
<asp:ListItem>209</asp:ListItem>
<asp:ListItem>210</asp:ListItem>
<asp:ListItem>211</asp:ListItem>
<asp:ListItem>212</asp:ListItem>
<asp:ListItem>213</asp:ListItem>
<asp:ListItem>214</asp:ListItem>
<asp:ListItem>215</asp:ListItem>
<asp:ListItem>216</asp:ListItem>
<asp:ListItem>217</asp:ListItem>
<asp:ListItem>218</asp:ListItem>
<asp:ListItem>219</asp:ListItem>
<asp:ListItem>220</asp:ListItem>
<asp:ListItem>221</asp:ListItem>
<asp:ListItem>222</asp:ListItem>
<asp:ListItem>223</asp:ListItem>
<asp:ListItem>224</asp:ListItem>
<asp:ListItem>225</asp:ListItem>
<asp:ListItem>226</asp:ListItem>
<asp:ListItem>227</asp:ListItem>
<asp:ListItem>228</asp:ListItem>
<asp:ListItem>229</asp:ListItem>
<asp:ListItem>230</asp:ListItem>
<asp:ListItem>231</asp:ListItem>
<asp:ListItem>232</asp:ListItem>
<asp:ListItem>233</asp:ListItem>
<asp:ListItem>234</asp:ListItem>
<asp:ListItem>235</asp:ListItem>
<asp:ListItem>236</asp:ListItem>
<asp:ListItem>237</asp:ListItem>
<asp:ListItem>238</asp:ListItem>
<asp:ListItem>239</asp:ListItem>
<asp:ListItem>240</asp:ListItem>
<asp:ListItem>241</asp:ListItem>
<asp:ListItem>242</asp:ListItem>
<asp:ListItem>243</asp:ListItem>
<asp:ListItem>244</asp:ListItem>
<asp:ListItem>245</asp:ListItem>
<asp:ListItem>246</asp:ListItem>
<asp:ListItem>247</asp:ListItem>
<asp:ListItem>248</asp:ListItem>
<asp:ListItem>249</asp:ListItem>
<asp:ListItem>250</asp:ListItem>
<asp:ListItem>251</asp:ListItem>
<asp:ListItem>252</asp:ListItem>
<asp:ListItem>253</asp:ListItem>
<asp:ListItem>254</asp:ListItem>
<asp:ListItem>255</asp:ListItem>
<asp:ListItem>256</asp:ListItem>
<asp:ListItem>257</asp:ListItem>
<asp:ListItem>258</asp:ListItem>
<asp:ListItem>259</asp:ListItem>
<asp:ListItem>260</asp:ListItem>
<asp:ListItem>261</asp:ListItem>
<asp:ListItem>262</asp:ListItem>
<asp:ListItem>263</asp:ListItem>
<asp:ListItem>264</asp:ListItem>
<asp:ListItem>265</asp:ListItem>
<asp:ListItem>266</asp:ListItem>
<asp:ListItem>267</asp:ListItem>
<asp:ListItem>268</asp:ListItem>
<asp:ListItem>269</asp:ListItem>
<asp:ListItem>270</asp:ListItem>
<asp:ListItem>271</asp:ListItem>
<asp:ListItem>272</asp:ListItem>
<asp:ListItem>273</asp:ListItem>
<asp:ListItem>274</asp:ListItem>
<asp:ListItem>275</asp:ListItem>
<asp:ListItem>276</asp:ListItem>
<asp:ListItem>277</asp:ListItem>
<asp:ListItem>278</asp:ListItem>
<asp:ListItem>279</asp:ListItem>
<asp:ListItem>280</asp:ListItem>
<asp:ListItem>281</asp:ListItem>
<asp:ListItem>282</asp:ListItem>
<asp:ListItem>283</asp:ListItem>
<asp:ListItem>284</asp:ListItem>
<asp:ListItem>285</asp:ListItem>
<asp:ListItem>286</asp:ListItem>
<asp:ListItem>287</asp:ListItem>
<asp:ListItem>288</asp:ListItem>
<asp:ListItem>289</asp:ListItem>
<asp:ListItem>290</asp:ListItem>
<asp:ListItem>291</asp:ListItem>
<asp:ListItem>292</asp:ListItem>
<asp:ListItem>293</asp:ListItem>
<asp:ListItem>294</asp:ListItem>
<asp:ListItem>295</asp:ListItem>
<asp:ListItem>296</asp:ListItem>
<asp:ListItem>297</asp:ListItem>
<asp:ListItem>298</asp:ListItem>
<asp:ListItem>299</asp:ListItem>
<asp:ListItem>300</asp:ListItem>
<asp:ListItem>301</asp:ListItem>
<asp:ListItem>302</asp:ListItem>
<asp:ListItem>303</asp:ListItem>
<asp:ListItem>304</asp:ListItem>
<asp:ListItem>305</asp:ListItem>
<asp:ListItem>306</asp:ListItem>
<asp:ListItem>307</asp:ListItem>
<asp:ListItem>308</asp:ListItem>
<asp:ListItem>309</asp:ListItem>
<asp:ListItem>310</asp:ListItem>
<asp:ListItem>311</asp:ListItem>
<asp:ListItem>312</asp:ListItem>
<asp:ListItem>313</asp:ListItem>
<asp:ListItem>314</asp:ListItem>
<asp:ListItem>315</asp:ListItem>
<asp:ListItem>316</asp:ListItem>
<asp:ListItem>317</asp:ListItem>
<asp:ListItem>318</asp:ListItem>
<asp:ListItem>319</asp:ListItem>
<asp:ListItem>320</asp:ListItem>
<asp:ListItem>321</asp:ListItem>
<asp:ListItem>322</asp:ListItem>
<asp:ListItem>323</asp:ListItem>
<asp:ListItem>324</asp:ListItem>
<asp:ListItem>325</asp:ListItem>
<asp:ListItem>326</asp:ListItem>
<asp:ListItem>327</asp:ListItem>
<asp:ListItem>328</asp:ListItem>
<asp:ListItem>329</asp:ListItem>
<asp:ListItem>330</asp:ListItem>
<asp:ListItem>331</asp:ListItem>
<asp:ListItem>332</asp:ListItem>
<asp:ListItem>333</asp:ListItem>
<asp:ListItem>334</asp:ListItem>
<asp:ListItem>335</asp:ListItem>
<asp:ListItem>336</asp:ListItem>
<asp:ListItem>337</asp:ListItem>
<asp:ListItem>338</asp:ListItem>
<asp:ListItem>339</asp:ListItem>
<asp:ListItem>340</asp:ListItem>
<asp:ListItem>341</asp:ListItem>
<asp:ListItem>342</asp:ListItem>
<asp:ListItem>343</asp:ListItem>
<asp:ListItem>344</asp:ListItem>
<asp:ListItem>345</asp:ListItem>
<asp:ListItem>346</asp:ListItem>
<asp:ListItem>347</asp:ListItem>
<asp:ListItem>348</asp:ListItem>
<asp:ListItem>349</asp:ListItem>
<asp:ListItem>350</asp:ListItem>
<asp:ListItem>351</asp:ListItem>
<asp:ListItem>352</asp:ListItem>
<asp:ListItem>353</asp:ListItem>
<asp:ListItem>354</asp:ListItem>
<asp:ListItem>355</asp:ListItem>
<asp:ListItem>356</asp:ListItem>
<asp:ListItem>357</asp:ListItem>
<asp:ListItem>358</asp:ListItem>
<asp:ListItem>359</asp:ListItem>
<asp:ListItem>360</asp:ListItem>
<asp:ListItem>361</asp:ListItem>
<asp:ListItem>362</asp:ListItem>
<asp:ListItem>363</asp:ListItem>
<asp:ListItem>364</asp:ListItem>
<asp:ListItem>365</asp:ListItem>
<asp:ListItem>366</asp:ListItem>
<asp:ListItem>367</asp:ListItem>
<asp:ListItem>368</asp:ListItem>
<asp:ListItem>369</asp:ListItem>
<asp:ListItem>370</asp:ListItem>
<asp:ListItem>371</asp:ListItem>
<asp:ListItem>372</asp:ListItem>
<asp:ListItem>373</asp:ListItem>
<asp:ListItem>374</asp:ListItem>
<asp:ListItem>375</asp:ListItem>
<asp:ListItem>376</asp:ListItem>
<asp:ListItem>377</asp:ListItem>
<asp:ListItem>378</asp:ListItem>
<asp:ListItem>379</asp:ListItem>
<asp:ListItem>380</asp:ListItem>
<asp:ListItem>381</asp:ListItem>
<asp:ListItem>382</asp:ListItem>
<asp:ListItem>383</asp:ListItem>
<asp:ListItem>384</asp:ListItem>
<asp:ListItem>385</asp:ListItem>
<asp:ListItem>386</asp:ListItem>
<asp:ListItem>387</asp:ListItem>
<asp:ListItem>388</asp:ListItem>
<asp:ListItem>389</asp:ListItem>
<asp:ListItem>390</asp:ListItem>
<asp:ListItem>391</asp:ListItem>
<asp:ListItem>392</asp:ListItem>
<asp:ListItem>393</asp:ListItem>
<asp:ListItem>394</asp:ListItem>
<asp:ListItem>395</asp:ListItem>
<asp:ListItem>396</asp:ListItem>
<asp:ListItem>397</asp:ListItem>
<asp:ListItem>398</asp:ListItem>
<asp:ListItem>399</asp:ListItem>
<asp:ListItem>400</asp:ListItem>
<asp:ListItem>401</asp:ListItem>
<asp:ListItem>402</asp:ListItem>
<asp:ListItem>403</asp:ListItem>
<asp:ListItem>404</asp:ListItem>
<asp:ListItem>405</asp:ListItem>
<asp:ListItem>406</asp:ListItem>
<asp:ListItem>407</asp:ListItem>
<asp:ListItem>408</asp:ListItem>
<asp:ListItem>409</asp:ListItem>
<asp:ListItem>410</asp:ListItem>
<asp:ListItem>411</asp:ListItem>
<asp:ListItem>412</asp:ListItem>
<asp:ListItem>413</asp:ListItem>
<asp:ListItem>414</asp:ListItem>
<asp:ListItem>415</asp:ListItem>
<asp:ListItem>416</asp:ListItem>
<asp:ListItem>417</asp:ListItem>
<asp:ListItem>418</asp:ListItem>
<asp:ListItem>419</asp:ListItem>
<asp:ListItem>420</asp:ListItem>
<asp:ListItem>421</asp:ListItem>
<asp:ListItem>422</asp:ListItem>
<asp:ListItem>423</asp:ListItem>
<asp:ListItem>424</asp:ListItem>
<asp:ListItem>425</asp:ListItem>
<asp:ListItem>426</asp:ListItem>
<asp:ListItem>427</asp:ListItem>
<asp:ListItem>428</asp:ListItem>
<asp:ListItem>429</asp:ListItem>
<asp:ListItem>430</asp:ListItem>
<asp:ListItem>431</asp:ListItem>
<asp:ListItem>432</asp:ListItem>
<asp:ListItem>433</asp:ListItem>
<asp:ListItem>434</asp:ListItem>
<asp:ListItem>435</asp:ListItem>
<asp:ListItem>436</asp:ListItem>
<asp:ListItem>437</asp:ListItem>
<asp:ListItem>438</asp:ListItem>
<asp:ListItem>439</asp:ListItem>
<asp:ListItem>440</asp:ListItem>
<asp:ListItem>441</asp:ListItem>
<asp:ListItem>442</asp:ListItem>
<asp:ListItem>443</asp:ListItem>
<asp:ListItem>444</asp:ListItem>
<asp:ListItem>445</asp:ListItem>
<asp:ListItem>446</asp:ListItem>
<asp:ListItem>447</asp:ListItem>
<asp:ListItem>448</asp:ListItem>
<asp:ListItem>449</asp:ListItem>
<asp:ListItem>450</asp:ListItem>
<asp:ListItem>451</asp:ListItem>
<asp:ListItem>452</asp:ListItem>
<asp:ListItem>453</asp:ListItem>
<asp:ListItem>454</asp:ListItem>
<asp:ListItem>455</asp:ListItem>
<asp:ListItem>456</asp:ListItem>
<asp:ListItem>457</asp:ListItem>
<asp:ListItem>458</asp:ListItem>
<asp:ListItem>459</asp:ListItem>
<asp:ListItem>460</asp:ListItem>
<asp:ListItem>461</asp:ListItem>
<asp:ListItem>462</asp:ListItem>
<asp:ListItem>463</asp:ListItem>
<asp:ListItem>464</asp:ListItem>
<asp:ListItem>465</asp:ListItem>
<asp:ListItem>466</asp:ListItem>
<asp:ListItem>467</asp:ListItem>
<asp:ListItem>468</asp:ListItem>
<asp:ListItem>469</asp:ListItem>
<asp:ListItem>470</asp:ListItem>
<asp:ListItem>471</asp:ListItem>
<asp:ListItem>472</asp:ListItem>
<asp:ListItem>473</asp:ListItem>
<asp:ListItem>474</asp:ListItem>
<asp:ListItem>475</asp:ListItem>
<asp:ListItem>476</asp:ListItem>
<asp:ListItem>477</asp:ListItem>
<asp:ListItem>478</asp:ListItem>
<asp:ListItem>479</asp:ListItem>
<asp:ListItem>480</asp:ListItem>
<asp:ListItem>481</asp:ListItem>
<asp:ListItem>482</asp:ListItem>
<asp:ListItem>483</asp:ListItem>
<asp:ListItem>484</asp:ListItem>
<asp:ListItem>485</asp:ListItem>
<asp:ListItem>486</asp:ListItem>
<asp:ListItem>487</asp:ListItem>
<asp:ListItem>488</asp:ListItem>
<asp:ListItem>489</asp:ListItem>
<asp:ListItem>490</asp:ListItem>
<asp:ListItem>491</asp:ListItem>
<asp:ListItem>492</asp:ListItem>
<asp:ListItem>493</asp:ListItem>
<asp:ListItem>494</asp:ListItem>
<asp:ListItem>495</asp:ListItem>
<asp:ListItem>496</asp:ListItem>
<asp:ListItem>497</asp:ListItem>
<asp:ListItem>498</asp:ListItem>
<asp:ListItem>499</asp:ListItem>
<asp:ListItem>500</asp:ListItem>
                                            </asp:DropDownList>
                                            <br />
                                            <asp:PlaceHolder ID="plcProductWarning" runat="server"></asp:PlaceHolder>
                                            <br />
                                            <!--<button type="button" style="border-style: 0; opacity:1;-moz-opacity:1;filter:alpha(opacity=100);border-width: 0px; height:40px; width:160PX; border-radius: 5px; background-color: #D6252E; font-family:'Open Sans', Helvetica, sans-serif; vertical-align:top; font-weight:600; font-size:100%; color: white; text-decoration: none;">ADD TO CART&nbsp;&nbsp;<img src="Images/TransparentCart.png" style="vertical-align:text-bottom;"/></button>!-->
                                            <asp:ImageButton ID="btnAddToCart" runat="server" ImageUrl="~/Images/AddToCartButton.png" />
                                            &nbsp;&nbsp;<asp:ImageButton ID="btnCheckOut" runat="server" ImageUrl="~/Images/CheckOutButton.png" Visible="False" />
                                            <br /><br />
                                            <asp:PlaceHolder ID="plcItemAdded" runat="server"></asp:PlaceHolder>
                                            <br /><br />
                                        </td>
                                        <td style="text-align:center;vertical-align:middle;">
                                            <asp:PlaceHolder ID="plcProductImage" runat="server"></asp:PlaceHolder>
                                        </td>
                                    </tr>
                                </table>    
                            </td>
                            <td style="width: 8.25%; text-align: center;"></td>
                        </tr>
                    </table>
                    <!-- #include file="Includes/Footer.aspx -->
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
