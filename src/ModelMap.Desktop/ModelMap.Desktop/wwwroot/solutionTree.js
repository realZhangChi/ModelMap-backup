
export function toggle(id) {
    const toggle = $(`#${id}`);
    const indicator = toggle.find('i.indicator');
    if (indicator.length > 0) {
        const isOpening = indicator.attr('class').includes('right');
        const indicatorClass = isOpening ? 'indicator mr-1 fa fa-fw fa-chevron-down' : 'indicator mr-1 fa fa-fw fa-chevron-right';
        indicator.attr('class', indicatorClass);
        const icon = toggle.find('i.icon');
        if (icon.length > 0 && icon.attr('class').includes('folder')) {
            const iconClass = isOpening ? 'icon mr-1 fa fa-fw fa-folder-open' : 'icon mr-1 fa fa-fw fa-folder';
            icon.attr('class', iconClass);
        }
    }
    const collapse = toggle.next();
    if (collapse.length > 0 && collapse.attr('class').includes('collaps')) {
        collapse.collapse('toggle');
    }
}