var common = new function () {
    this.DateTrim = function (date) {
        var temp = date.replace('00:00:00', '').replace('0:00:00', '').replace('1900/1/1', '');
        if ($.trim(temp) == "1900-01-01")
            return "";
        else if ($.trim(temp) == "1900-1-1")
            return "";
        else
            return temp;
    },
    this.GetAllCheckedVal = function (wrap) {
        var result = "";
        $("#" + wrap + " input:checked[class=cbxid]").each(function (index) {
            if (index > 0)
                result += ",";
            result += $(this).val();
        });
        return result;
    },
    this.Success = function (tip) {
        ZENG.msgbox.show(tip, 4, 2000);
    },
    this.Error = function (tip) {
        ZENG.msgbox.show(tip, 5, 2500)
    },
    this.Loading = function (tip) {
        ZENG.msgbox.show(tip, 6);
    },
    this.TipHide = function () {
        ZENG.msgbox._hide();
    },
    this.AjaxHandle = function (url, parm, callback) {
        $.ajax({
            type: "post",
            url: url,
            cache: false,
            data: parm,
            beforeSend: function () { common.Loading("处理中..."); },
            success: callback,
            error: function (XMLHttpRequest) { common.Error("服务器繁忙，请稍后再试..."); },
            complete: function (XMLHttpRequest) { XMLHttpRequest = null; }
        });
    },
    this.AjaxWithTip = function (url, parm, callback) {
        $.ajax({
            type: "post",
            url: url,
            cache: false,
            data: parm,
            beforeSend: function () { common.Loading("正在加载中，请稍后..."); },
            success: callback,
            error: function (XMLHttpRequest) { common.Error("服务器繁忙，请稍后再试..."); },
            complete: function (XMLHttpRequest) { common.TipHide(); XMLHttpRequest = null; }
        });
    },
     this.AjaxNoLoad = function (url, parm, callback) {
         $.ajax({
             type: "post",
             url: url,
             cache: false,
             data: parm,
             success: callback,
             complete: function (XMLHttpRequest) { XMLHttpRequest = null; }
         });
     },
    this.format = function () {
        if (arguments.length == 0)
            return null;
        var str = arguments[0];
        for (var i = 1; i < arguments.length; i++) {
            var re = new RegExp('\\{' + (i - 1) + '\\}', 'gm');
            str = str.replace(re, arguments[i]);
        }
        return str;
    },
    this.GetPagerToolBar = function (pageindex, pagesize, total, methods) {
        var pagecount = Math.ceil(total / pagesize);
        var tools = "";
        for (var i = (pageindex - 2) > 0 ? (pageindex - 2) : 1; i <= ((pageindex + 2) < pagecount ? (pageindex + 2) : pagecount); i++) {
            if (i == pageindex)
                tools += common.format("<li><a id=\"currentPageIndex\"  href=javascript:void(0) onclick={1}({0},{2})>{0}</a></li>", i, methods, pagesize);
            else
                tools += common.format("<li><a  href=javascript:void(0) onclick={1}({0},{2})>{0}</a></li>", i, methods, pagesize);
        }
        if ((pageindex + 3) < pagecount) {
            tools += "<li>...</li>";
            tools += common.format("<li><a href=javascript:void(0) onclick={1}({0},{2})>{0}</a></li>", pagecount, methods, pagesize);
        }
        return tools;
    }
}

window.ZENG = window.ZENG || {};

ZENG.dom = { getById: function (id) {
    return document.getElementById(id);
}, get: function (e) {
    return (typeof (e) == "string") ? document.getElementById(e) : e;
}, createElementIn: function (tagName, elem, insertFirst, attrs) {
    var _e = (elem = ZENG.dom.get(elem) || document.body).ownerDocument.createElement(tagName || "div"), k;
    if (typeof (attrs) == 'object') {
        for (k in attrs) {
            if (k == "class") {
                _e.className = attrs[k];
            } else if (k == "style") {
                _e.style.cssText = attrs[k];
            } else {
                _e[k] = attrs[k];
            }
        }
    }
    insertFirst ? elem.insertBefore(_e, elem.firstChild) : elem.appendChild(_e);
    return _e;
}, getStyle: function (el, property) {
    el = ZENG.dom.get(el);
    if (!el || el.nodeType == 9) {
        return null;
    }
    var w3cMode = document.defaultView && document.defaultView.getComputedStyle, computed = !w3cMode ? null : document.defaultView.getComputedStyle(el, ''), value = "";
    switch (property) {
        case "float":
            property = w3cMode ? "cssFloat" : "styleFloat";
            break;
        case "opacity":
            if (!w3cMode) {
                var val = 100;
                try {
                    val = el.filters['DXImageTransform.Microsoft.Alpha'].opacity;
                } catch (e) {
                    try {
                        val = el.filters('alpha').opacity;
                    } catch (e) {
                    }
                }
                return val / 100;
            } else {
                return parseFloat((computed || el.style)[property]);
            }
            break;
        case "backgroundPositionX":
            if (w3cMode) {
                property = "backgroundPosition";
                return ((computed || el.style)[property]).split(" ")[0];
            }
            break;
        case "backgroundPositionY":
            if (w3cMode) {
                property = "backgroundPosition";
                return ((computed || el.style)[property]).split(" ")[1];
            }
            break;
    }
    if (w3cMode) {
        return (computed || el.style)[property];
    } else {
        return (el.currentStyle[property] || el.style[property]);
    }
}, setStyle: function (el, properties, value) {
    if (!(el = ZENG.dom.get(el)) || el.nodeType != 1) {
        return false;
    }
    var tmp, bRtn = true, w3cMode = (tmp = document.defaultView) && tmp.getComputedStyle, rexclude = /z-?index|font-?weight|opacity|zoom|line-?height/i;
    if (typeof (properties) == 'string') {
        tmp = properties;
        properties = {};
        properties[tmp] = value;
    }
    for (var prop in properties) {
        value = properties[prop];
        if (prop == 'float') {
            prop = w3cMode ? "cssFloat" : "styleFloat";
        } else if (prop == 'opacity') {
            if (!w3cMode) {
                prop = 'filter';
                value = value >= 1 ? '' : ('alpha(opacity=' + Math.round(value * 100) + ')');
            }
        } else if (prop == 'backgroundPositionX' || prop == 'backgroundPositionY') {
            tmp = prop.slice(-1) == 'X' ? 'Y' : 'X';
            if (w3cMode) {
                var v = ZENG.dom.getStyle(el, "backgroundPosition" + tmp);
                prop = 'backgroundPosition';
                typeof (value) == 'number' && (value = value + 'px');
                value = tmp == 'Y' ? (value + " " + (v || "top")) : ((v || 'left') + " " + value);
            }
        }
        if (typeof el.style[prop] != "undefined") {
            el.style[prop] = value + (typeof value === "number" && !rexclude.test(prop) ? 'px' : '');
            bRtn = bRtn && true;
        } else {
            bRtn = bRtn && false;
        }
    }
    return bRtn;
}, getScrollTop: function (doc) {
    var _doc = doc || document;
    return Math.max(_doc.documentElement.scrollTop, _doc.body.scrollTop);
}, getClientHeight: function (doc) {
    var _doc = doc || document;
    return _doc.compatMode == "CSS1Compat" ? _doc.documentElement.clientHeight : _doc.body.clientHeight;
}
};

function ShowSuccessTips(tip) {
    ZENG.msgbox.show(tip, 4, 1500);
}
function ShowErrorTips(tip) {
    ZENG.msgbox.show(tip, 5, 2000)
}
//得到表单序列化后的json字符串，name为键
function GetJsonString(formid) {
    return JSON.stringify($('#' + formid).form_serialize('json'));
}
//得到表单序列化后的json对象，name为键
function GetJsonObject(formid) {
    return $('#' + formid).form_serialize('json');
}
//把字符串转换为json对象
function JsonFormat(msg) {
    while (msg.indexOf("\r\n") >= 0) {
        msg = msg.replace("\r\n", "\\r\\n");
    }
    var result = eval('(' + msg + ')');
    return result;
}


ZENG.string = { RegExps: { trim: /^\s+|\s+$/g, ltrim: /^\s+/, rtrim: /\s+$/, nl2br: /\n/g, s2nb: /[\x20]{2}/g, URIencode: /[\x09\x0A\x0D\x20\x21-\x29\x2B\x2C\x2F\x3A-\x3F\x5B-\x5E\x60\x7B-\x7E]/g, escHTML: { re_amp: /&/g, re_lt: /</g, re_gt: />/g, re_apos: /\x27/g, re_quot: /\x22/g }, escString: { bsls: /\\/g, sls: /\//g, nl: /\n/g, rt: /\r/g, tab: /\t/g }, restXHTML: { re_amp: /&amp;/g, re_lt: /&lt;/g, re_gt: /&gt;/g, re_apos: /&(?:apos|#0?39);/g, re_quot: /&quot;/g }, write: /\{(\d{1,2})(?:\:([xodQqb]))?\}/g, isURL: /^(?:ht|f)tp(?:s)?\:\/\/(?:[\w\-\.]+)\.\w+/i, cut: /[\x00-\xFF]/, getRealLen: { r0: /[^\x00-\xFF]/g, r1: /[\x00-\xFF]/g }, format: /\{([\d\w\.]+)\}/g }, commonReplace: function (s, p, r) {
    return s.replace(p, r);
}, format: function (str) {
    var args = Array.prototype.slice.call(arguments), v;
    str = String(args.shift());
    if (args.length == 1 && typeof (args[0]) == 'object') {
        args = args[0];
    }
    ZENG.string.RegExps.format.lastIndex = 0;
    return str.replace(ZENG.string.RegExps.format, function (m, n) {
        v = ZENG.object.route(args, n);
        return v === undefined ? m : v;
    });
}
};


ZENG.object = {
    routeRE: /([\d\w_]+)/g,
    route: function (obj, path) {
        obj = obj || {};
        path = String(path);
        var r = ZENG.object.routeRE, m;
        r.lastIndex = 0;
        while ((m = r.exec(path)) !== null) {
            obj = obj[m[0]];
            if (obj === undefined || obj === null) {
                break;
            }
        }
        return obj;
    }
};



var ua = ZENG.userAgent = {}, agent = navigator.userAgent;
ua.ie = 9 - ((agent.indexOf('Trident/5.0') > -1) ? 0 : 1) - (window.XDomainRequest ? 0 : 1) - (window.XMLHttpRequest ? 0 : 1);



if (typeof (ZENG.msgbox) == 'undefined') {
    ZENG.msgbox = {};
}
ZENG.msgbox._timer = null;
ZENG.msgbox.loadingAnimationPath = ZENG.msgbox.loadingAnimationPath || ("http://static.91gold.com/Content/images/loading.gif");
ZENG.msgbox.show = function (msgHtml, type, timeout, opts) {
    if (typeof (opts) == 'number') {
        opts = { topPosition: opts };
    }
    opts = opts || {};
    var _s = ZENG.msgbox,
	 template = '<span class="zeng_msgbox_layer" style="display:none;z-index:10000;" id="mode_tips_v2"><span class="gtl_ico_{type}"></span>{loadIcon}{msgHtml}<span class="gtl_end"></span></span>', loading = '<span class="gtl_ico_loading"></span>', typeClass = [0, 0, 0, 0, "succ", "fail", "clear"], mBox, tips;
    _s._loadCss && _s._loadCss(opts.cssPath);
    mBox = ZENG.dom.get("q_Msgbox") || ZENG.dom.createElementIn("div", document.body, false, { className: "zeng_msgbox_layer_wrap" });
    mBox.id = "q_Msgbox";
    mBox.style.display = "";
    mBox.innerHTML = ZENG.string.format(template, { type: typeClass[type] || "hits", msgHtml: msgHtml || "", loadIcon: type == 6 ? loading : "" });
    _s._setPosition(mBox, timeout, opts.topPosition);
};
ZENG.msgbox._setPosition = function (tips, timeout, topPosition) {
    timeout = timeout || 5000;
    var _s = ZENG.msgbox, bt = ZENG.dom.getScrollTop(), ch = ZENG.dom.getClientHeight(), t = Math.floor(ch / 2) - 40;
    ZENG.dom.setStyle(tips, "top", ((document.compatMode == "BackCompat" || ZENG.userAgent.ie < 7) ? bt : 0) + ((typeof (topPosition) == "number") ? topPosition : t) + "px");
    clearTimeout(_s._timer);
    tips.firstChild.style.display = "";
    timeout && (_s._timer = setTimeout(_s.hide, timeout));
};
ZENG.msgbox.hide = function (timeout) {
    var _s = ZENG.msgbox;
    if (timeout) {
        clearTimeout(_s._timer);
        _s._timer = setTimeout(_s._hide, timeout);
    } else {
        _s._hide();
    }
};
ZENG.msgbox._hide = function () {
    var _mBox = ZENG.dom.get("q_Msgbox"), _s = ZENG.msgbox;
    clearTimeout(_s._timer);
    if (_mBox) {
        var _tips = _mBox.firstChild;
        ZENG.dom.setStyle(_mBox, "display", "none");
    }
};

/*时间 默认为空的时候就用 1900-01-01*/
function DateTrim(date) {
    var temp = date.replace('00:00:00', '').replace('0:00:00', '').replace('1900/1/1', '');
    if ($.trim(temp) == "1900-01-01")
        return "";
    else if ($.trim(temp) == "1900-1-1")
        return "";
    else
        return temp;
}

//只更新修改了值的列，通常用作列表中直接修改的情况
function GeUpdateParm(container) {
    // InitTimeParm(container);
    var result = "[";
    var name = "";
    var oldvalue = "";
    var value = "";
    $("#" + container + " input,#" + container + " select,#" + container + " password").each(function (i) {
        name = $(this).attr("name");
        if (name != "undefined" && name != null) {
            oldvalue = $.trim($(this).attr("oldvalue"));
            value = $.trim($(this).val());
            if (name.indexOf("t_") < 0 && value != oldvalue) {
                result += "{field:'" + name;
                result += "',value:'" + value + "'},";
            }
        }
    });
    if (result == "[")
        return "";
    else
        return result.substring(0, result.length - 1) + "]";
}

function GetSearchParm(container) {
    var result = "[";
    var id = "";
    var value = "";
    $("#" + container + " input,#" + container + " select").each(function (i) {
        value = $.trim($(this).val());
        name = $(this).attr("name");
        if (name.indexOf("w_") >= 0 && value != "") {
            result += String.format("{\"field\":\"{0}\",\"comparison\":\"{1}\",\"value\":\"{2}\"},"
            , encodeURI(name.substring(4, name.length)), encodeURI(name.substring(2, 3)), encodeURI(value));
        }
    });
    if (result == "[")
        return "";
    else
        return result.substring(0, result.length - 1) + "]";
}
//字符串拼接
String.format = function () {
    if (arguments.length == 0)
        return null;
    var str = arguments[0];
    for (var i = 1; i < arguments.length; i++) {
        var re = new RegExp('\\{' + (i - 1) + '\\}', 'gm');
        str = str.replace(re, arguments[i]);
    }
    return str;
}

var getQueryString = function (name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}