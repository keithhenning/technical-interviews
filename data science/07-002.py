from pysyncon import Dataprep, Synth
prep = Dataprep(
    foo=panel, predictors=["log_bookings"], predictors_op="mean",
    dependent="log_bookings", unit_variable="market",
    time_variable="week", treatment_identifier="Denver",
    controls_identifier=donor_markets,
    time_predictors_prior=range(1, 105), time_optimize_ssr=range(1, 105))
synth = Synth()
synth.fit(dataprep=prep)
effect = synth.att(time_period=range(105, 130))
