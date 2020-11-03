export const groupBy = (list: Array<any>, prop: string) => {
  return list.reduce((groups, item) => {
    let val = item;

    prop.split(".").forEach(element => {
      val = val[element];
    });

    groups[val] = groups[val] || [];
    groups[val].push(item);
    return groups;
  }, {});
};
