// This is a JavaScript module that is loaded on demand. It can export any number of
// functions, and may import other JavaScript modules if required.

var canvas;

export function init(id) {
    canvas = new fabric.Canvas(id, {
        fireRightClick: true,  // <-- enable firing of right click events
        //stopContextMenu: true, // <--  prevent context menu from showing
    });
    setDimensions();
    new ResizeObserver(setDimensions).observe(document.getElementsByClassName('canvas-container')[0].parentElement);
    //document.getElementsByClassName('canvas-container')[0].parentElement.onresize = function () { setDimensions(); };

    //for (var x = -50000; x <= 50000; x += 20) {
    //    var strokeWidth = 1;
    //    if (x % 100 === 0) {
    //        strokeWidth = 2;
    //    }
    //    var line = new fabric.Line([x, -50000, x, 50000], {
    //        stroke: 'rgba(240,248,255,1)',
    //        strokeWidth: strokeWidth,
    //        selectable: false
    //    });
    //    canvas.add(line);
    //}
    //for (var y = -50000; y <= 50000; y += 20) {
    //    var strokeWidth = 1;
    //    if (y % 100 === 0) {
    //        strokeWidth = 2;
    //    }
    //    var line = new fabric.Line([-50000, y, 50000, y], {
    //        stroke: 'rgba(240,248,255,1)',
    //        strokeWidth: strokeWidth,
    //        selectable: false
    //    });
    //    canvas.add(line);
    //}

    canvas.on('mouse:down', function (opt) {
        var evt = opt.e;
        if (evt.altKey === true) {
            this.isDragging = true;
            this.selection = false;
            this.lastPosX = evt.clientX;
            this.lastPosY = evt.clientY;
        }
    });

    canvas.on('mouse:move', function (opt) {
        if (this.isDragging) {
            var e = opt.e;
            var vpt = this.viewportTransform;
            vpt[4] += e.clientX - this.lastPosX;
            vpt[5] += e.clientY - this.lastPosY;
            this.requestRenderAll();
            this.lastPosX = e.clientX;
            this.lastPosY = e.clientY;
        }
    });

    canvas.on('mouse:up', function (opt) {
        // on mouse up we want to recalculate new interaction
        // for all objects, so we call setViewportTransform
        this.setViewportTransform(this.viewportTransform);
        this.isDragging = false;
        this.selection = true;
    });

    canvas.on('mouse:wheel',
        function (opt) {
            var delta = opt.e.deltaY;
            var zoom = canvas.getZoom();
            zoom *= 0.999 ** delta;
            if (zoom > 5) zoom = 5;
            if (zoom < 0.5) zoom = 0.5;
            canvas.zoomToPoint({ x: opt.e.offsetX, y: opt.e.offsetY }, zoom);
            opt.e.preventDefault();
            opt.e.stopPropagation();
        });

    canvas.on('object:moved', function (event) {
        if (event.target.get('type') === 'EntityGroup') {
            window.designerInvokeHelper.invokeMethodAsync('UpdateEntityPositionAsync', event.target.model.id, event.target.top, event.target.left)
                .then(() => {
                    console.log('.net invoke sucess!')
                });
        }
    });
};

export function loadFromJSON(json) {
    canvas.loadFromJSON(json);
    canvas.renderAll();
}

export function toJson() {
    return JSON.stringify(canvas);
}

export function addEntity(model) {
    var nameHeight = 20;
    var itemHeight = 24;
    var partialSpacing = 6;
    var partQuantity = 2;
    var options = {};
    options.shadow = { color: "rgba(0, 0, 0, 0.3)", blur: 10, offsetX: 3, offsetY: 3 };
    options.width = 180;
    options.height = nameHeight +
        (model.properties.length) * itemHeight +
        (partQuantity - 1) * partialSpacing;


    var dimensions = getContainerDimensions();
    options.left = model.position.left;
    options.top = model.position.top;

    var objects = [];

    // background
    var background = new fabric.Rect({
        width: options.width,
        height: options.height,
        originX: 'center',
        originY: 'center',
        fill: 'rgba(248,249,250,1)'
    });
    objects.push(background);

    // name part
    var top = -options.height / 2;
    var nameTextBox = new fabric.Textbox(model.name,
        {
            width: options.width,
            height: 100,
            originX: 'center',
            originY: 'top',
            top: top,
            textAlign: 'left',
            fontSize: 18,
            fill: '#fff',
            fontFamily: "'Helvetica Neue', Helvetica, Arial, sans-serif",
            backgroundColor: 'rgba(0,123,255,1)'
        });
    top += nameHeight;
    objects.push(nameTextBox);
    top += partialSpacing;

    // property part
    for (var i = 0; i < model.properties.length; i++, top += itemHeight) {
        var property = new fabric.Textbox(model.properties[i].name,
            {
                width: options.width,
                height: itemHeight,
                originX: 'top',
                originY: 'top',
                top: top,
                textAlign: 'left',
                fontSize: 14,
                fill: '#343a40',
                fontFamily: "'Helvetica Neue', Helvetica, Arial, sans-serif"
            });
        objects.push(property);
    }
    //if (this.model.methods && this.model.methods.length > 0) {
    //    var line = new fabric.Line([-innerOptions.width / 2, top, innerOptions.width / 2, top], {
    //        stroke: '#007bff',
    //        selectable: false
    //    });
    //    objects.push(line);
    //    top += partialSpacing;

    //    // method part
    //    for (var j = 0; j < this.model.methods.length; j++, top += itemHeight) {
    //        var method = new fabric.Textbox(this.model.methods[j].name,
    //            {
    //                width: innerOptions.width,
    //                height: itemHeight,
    //                originX: 'top',
    //                originY: 'top',
    //                top: top,
    //                textAlign: 'left',
    //                fontSize: 14,
    //                fill: '#343a40',
    //                fontFamily: "'Helvetica Neue', Helvetica, Arial, sans-serif"
    //            });
    //        objects.push(method);
    //    }
    //}
    options.model = model;
    var classComponent = new fabric.EntityGroup(objects, options);
    classComponent.setControlsVisibility({
        mt: false,
        mb: false,
        ml: false,
        mr: false,
        bl: false,
        br: false,
        tl: false,
        tr: false,
        mtr: false,
    });
    classComponent.on('mouseup', function (event) {
        if (event.button === 3) {
            canvas.setActiveObject(event.target);
            window.designerInvokeHelper.invokeMethodAsync('ShowCanvasContextMenuAsync', event.target.model.id, event.e.clientX, event.e.clientY)
                .then(() => {
                    console.log('.net invoke sucess!')
                });
        }
    })
    canvas.add(classComponent);
    canvas.setActiveObject(classComponent);
    canvas.renderAll();
}

export function removeEntity(id) {
    let entity = canvas.getActiveObject();
    if (entity &&
        entity.get('type') === 'EntityGroup' &&
        entity.get('model').id === id) {
        canvas.remove(entity);
    }
    else {

    }
}

export function getCenterX() {
    return canvas.getVpCenter().x;
}

export function getCenterY() {
    return canvas.getVpCenter().y;
}

function setDimensions() {
    var container = getContainerDimensions();
    canvas.setDimensions({
        width: container.width,
        height: container.height
    });
}

function getContainerDimensions() {
    var container = document.getElementsByClassName('canvas-container')[0].parentElement;
    return {
        width: container.offsetWidth,
        height: container.offsetHeight
    }
}

fabric.EntityGroup = fabric.util.createClass(fabric.Group, {

    type: 'EntityGroup',

    initialize: function (objects, options) {
        options || (options = {});

        this.callSuper('initialize', objects, options);
        this.set('model', options.model || {});
    },

    toObject: function () {
        return fabric.util.object.extend(this.callSuper('toObject'), {
            model: this.model,
            model_type: 'entity'
        });
    },

    _render: function (ctx) {
        this.callSuper('_render', ctx);
    }
});

fabric.EntityGroup.fromObject = function (object, callback) {
    var _enlivenedObjects;
    fabric.util.enlivenObjects(object.objects, function (enlivenedObjects) {
        delete object.objects;
        _enlivenedObjects = enlivenedObjects;
        var entityGroup = new fabric.EntityGroup(_enlivenedObjects, object);
        entityGroup.setControlsVisibility({
            mt: false,
            mb: false,
            ml: false,
            mr: false,
            bl: false,
            br: false,
            tl: false,
            tr: false,
            mtr: false,
        });
        callback(entityGroup);
    });
};
