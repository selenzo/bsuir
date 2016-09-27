function Canvas() {
    var _obj = {},
        canvas = null,
        x = 0,
        y = 0,
        scale = 1,
        polygon = null,
        m_canvas = null,
        temp = 0,
        scaleDirection = true,
        scaleEnt = 0,
        polyCoords = [
            [80, 0],
            [160, 70],
            [160, 160],
            [80, 230],
            [0, 160],
            [0, 70]
        ];

    function DrawPoly(coords) {
        polygon.setTransform(scale, 0, 0, scale, 0, 0);
        polygon.beginPath();
        polygon.moveTo(coords[0][0], coords[0][1]);
        for (var i = 1; i < coords.length; i++) {
            polygon.lineTo(coords[i][0], coords[i][1]);
        }
        polygon.closePath();
        polygon.fill();
    }

    function Rand() {
        return Math.round(Math.random() * 2 * (Math.round(Math.random()) ? -1 : 1));
    }

    function Clear() {
        m_canvas.getContext("2d").setTransform(1, 0, 0, 1, 0, 0);
        canvas.getContext("2d").clearRect(0, 0, canvas.width, canvas.height);
        m_canvas.getContext("2d").clearRect(0, 0, m_canvas.width, m_canvas.height);
    }

    _obj.Init = function (canvasId) {
        canvas = document.getElementById(canvasId);
        m_canvas = document.createElement('canvas');
        polygon = m_canvas.getContext('2d');
        m_canvas.width = 160; //80
        m_canvas.height = 230; //115
        setInterval(Tick, 10);
    }

    function Tick() {
        Clear();
        scaleEnt++;

        if (!(scaleEnt % 5)) {

            if (scaleDirection) {
                if (scale - 0.033 > 0) {
                    scale -= 0.033;
                } else {
                    scaleDirection = false;
                    scale += 0.033;
                }
            } else {
                if (scale + 0.033 < 1) {
                    scale += 0.033;
                } else {
                    scaleDirection = true;
                    scale -= 0.033;
                }
            }
        }



        //        x += Rand();
        //        y += Rand();
        temp = Rand();
        x += (x + temp > 320 ? -2 : x + temp < 0 ? 2 : temp);
        temp = Rand();
        y += (y + temp > 320 ? -2 : y + temp < 0 ? 2 : temp);


        //        if (x > 320) {
        //            x -= 2;
        //        }
        //        if (x < 0) {
        //            x += 2;
        //        }
        //
        //        if (y > 270) {
        //            y -= 2;
        //        }
        //        if (y < 0) {
        //            y += 2;
        //        }
        console.log(x);
        DrawPoly(polyCoords);

        canvas.getContext('2d').drawImage(m_canvas, 80 - 80 * scale + x, 115 - 115 * scale + y);
    }
    return _obj;
}

window.onload = function () {
    var a = Canvas();
    a.Init("canvas");
}
