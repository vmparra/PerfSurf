(function () {

    Array.prototype.reverse() = function () {
        var self = this;
        var i;
        for (i = 0; i < self.length() / 2; i++) {
            var first = self[i];
            var second = self[self.length() - i - 1];
            self[self.length() - i - 1] = first;
            self[i] = second;
        }
    };

    $(function () {
        ;
    });
}
());